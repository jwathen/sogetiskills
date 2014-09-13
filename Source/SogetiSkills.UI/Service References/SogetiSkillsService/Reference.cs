﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SogetiSkills.UI.SogetiSkillsService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Profile", Namespace="http://us.sogeti.com/sogetiskills/1/")]
    [System.SerializableAttribute()]
    public partial class Profile : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Collections.Generic.List<SogetiSkills.UI.SogetiSkillsService.Skill> SkillsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UsernameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Bio {
            get {
                return this.BioField;
            }
            set {
                if ((object.ReferenceEquals(this.BioField, value) != true)) {
                    this.BioField = value;
                    this.RaisePropertyChanged("Bio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Collections.Generic.List<SogetiSkills.UI.SogetiSkillsService.Skill> Skills {
            get {
                return this.SkillsField;
            }
            set {
                if ((object.ReferenceEquals(this.SkillsField, value) != true)) {
                    this.SkillsField = value;
                    this.RaisePropertyChanged("Skills");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Username {
            get {
                return this.UsernameField;
            }
            set {
                if ((object.ReferenceEquals(this.UsernameField, value) != true)) {
                    this.UsernameField = value;
                    this.RaisePropertyChanged("Username");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Skill", Namespace="http://us.sogeti.com/sogetiskills/1/")]
    [System.SerializableAttribute()]
    public partial class Skill : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescriptionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SogetiSkillsService.ISogetiSkillsService")]
    public interface ISogetiSkillsService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISogetiSkillsService/GetVersion", ReplyAction="http://tempuri.org/ISogetiSkillsService/GetVersionResponse")]
        string GetVersion();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISogetiSkillsService/GetVersion", ReplyAction="http://tempuri.org/ISogetiSkillsService/GetVersionResponse")]
        System.Threading.Tasks.Task<string> GetVersionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISogetiSkillsService/Profile_GetByUsername", ReplyAction="http://tempuri.org/ISogetiSkillsService/Profile_GetByUsernameResponse")]
        SogetiSkills.UI.SogetiSkillsService.Profile Profile_GetByUsername(string username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISogetiSkillsService/Profile_GetByUsername", ReplyAction="http://tempuri.org/ISogetiSkillsService/Profile_GetByUsernameResponse")]
        System.Threading.Tasks.Task<SogetiSkills.UI.SogetiSkillsService.Profile> Profile_GetByUsernameAsync(string username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISogetiSkillsServiceChannel : SogetiSkills.UI.SogetiSkillsService.ISogetiSkillsService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SogetiSkillsServiceClient : System.ServiceModel.ClientBase<SogetiSkills.UI.SogetiSkillsService.ISogetiSkillsService>, SogetiSkills.UI.SogetiSkillsService.ISogetiSkillsService {
        
        public SogetiSkillsServiceClient() {
        }
        
        public SogetiSkillsServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SogetiSkillsServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SogetiSkillsServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SogetiSkillsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetVersion() {
            return base.Channel.GetVersion();
        }
        
        public System.Threading.Tasks.Task<string> GetVersionAsync() {
            return base.Channel.GetVersionAsync();
        }
        
        public SogetiSkills.UI.SogetiSkillsService.Profile Profile_GetByUsername(string username) {
            return base.Channel.Profile_GetByUsername(username);
        }
        
        public System.Threading.Tasks.Task<SogetiSkills.UI.SogetiSkillsService.Profile> Profile_GetByUsernameAsync(string username) {
            return base.Channel.Profile_GetByUsernameAsync(username);
        }
    }
}