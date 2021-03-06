﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SogetiSkills.Core.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using SogetiSkills.Core.Managers;
using SogetiSkills.Core.DatabaseMigrations;
using System.Data.SqlClient;
using WebMatrix.Data;

namespace SogetiSkills.Core.Tests.TestHelpers
{
    public class DbUnitTestBase : UnitTestBase
    {
        protected static Database TestDatabase = null;

        static DbUnitTestBase()
        {            
            string connectionString = ConfigurationManager.ConnectionStrings["SogetiSkills"].ConnectionString;
            SqlDatabaseMigrator migrator = new SqlDatabaseMigrator(connectionString, typeof(UserManager).Assembly, "SogetiSkills.Core.DatabaseMigrations");
            migrator.Migrate();

            TestDatabase = Database.Open("SogetiSkills");
            EmptyDatabase();
        }
        
        public static void EmptyDatabase()
        {
            var sqlStatements = new[] {
                "DELETE FROM Resumes",
                "DELETE FROM ConsultantSkill",
                "DELETE FROM Skills",
                "DELETE FROM Users",
                "DBCC CHECKIDENT ('Users', RESEED, 1)",
                "DBCC CHECKIDENT ('Resumes', RESEED, 1)",
                "DBCC CHECKIDENT ('Skills', RESEED, 1)"
            };
            
            foreach(string sqlStatement in sqlStatements)
            {
                TestDatabase.Execute(sqlStatement);
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            EmptyDatabase();
        }

        protected int InsertUser(User user)
        {
            string userType = null;
            bool isOnBeach = false;
            if (user is Consultant)
            {
                userType = AccountTypes.CONSULTANT;
                isOnBeach = ((Consultant)user).IsOnBeach;
            }
            else
            {
                userType = AccountTypes.ACCOUNT_EXECUTIVE;
            }

            string insertStatement = @"INSERT INTO Users (UserType, EmailAddress, FirstName, LastName, PhoneNumber, Password_Hash, Password_Salt, IsOnBeach)
                                       VALUES (@0, @1, @2, @3, @4, @5, @6, @7)";
            TestDatabase.Execute(insertStatement, userType, user.EmailAddress, user.FirstName, user.LastName, user.PhoneNumber.Value, user.Password.Hash, user.Password.Salt, isOnBeach);

            return (int)TestDatabase.GetLastInsertId();
        }

        protected int InsertResume(Resume resume)
        {
            TestDatabase.Execute("INSERT INTO Resumes (UserId, FileData, FileName, MimeType) VALUES (@0, @1, @2, @3)",
                resume.UserId, resume.FileData, resume.Metadata.FileName, resume.Metadata.MimeType);

            return (int)TestDatabase.GetLastInsertId();
        }

        protected Skill InsertSkill(string name, bool isCanonical)
        {
            TestDatabase.Execute("INSERT INTO Skills (Name, IsCanonical) VALUES (@0, @1)", name, isCanonical);

            int id = (int)TestDatabase.GetLastInsertId();
            return new Skill
            {
                Id = id,
                Name = name,                
                IsCanonical = isCanonical
            };
        }

        protected void InsertConsultantSkill(int consultantId, int skillId, int proficiencyLevel = 3)
        {
            TestDatabase.Execute("INSERT INTO ConsultantSkill(ConsultantId, SkillId, ProficiencyLevel) VALUES (@0, @1, @2)", consultantId, skillId, proficiencyLevel);
        }
    }
}
