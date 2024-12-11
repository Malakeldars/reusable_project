﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Reusable_project_Form_.UserServiceReference {
    using System.Data;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UserServiceReference.U_ServicesSoap")]
    public interface U_ServicesSoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CreateAccount", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool CreateAccount(string password, string fullname, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/CreateAccount", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> CreateAccountAsync(string password, string fullname, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ViewProjectTheme", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Data.DataTable ViewProjectTheme();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ViewProjectTheme", ReplyAction="*")]
        System.Threading.Tasks.Task<System.Data.DataTable> ViewProjectThemeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteProposal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool DeleteProposal(int submissionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/DeleteProposal", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> DeleteProposalAsync(int submissionid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateProposal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool UpdateProposal(int submissionid, string proposal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UpdateProposal", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> UpdateProposalAsync(int submissionid, string proposal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SubmitProposal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        bool SubmitProposal(int userid, int themeid, string proposal);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/SubmitProposal", ReplyAction="*")]
        System.Threading.Tasks.Task<bool> SubmitProposalAsync(int userid, int themeid, string proposal);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface U_ServicesSoapChannel : Reusable_project_Form_.UserServiceReference.U_ServicesSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class U_ServicesSoapClient : System.ServiceModel.ClientBase<Reusable_project_Form_.UserServiceReference.U_ServicesSoap>, Reusable_project_Form_.UserServiceReference.U_ServicesSoap {
        
        public U_ServicesSoapClient() {
        }
        
        public U_ServicesSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public U_ServicesSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public U_ServicesSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public U_ServicesSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool CreateAccount(string password, string fullname, string email) {
            return base.Channel.CreateAccount(password, fullname, email);
        }
        
        public System.Threading.Tasks.Task<bool> CreateAccountAsync(string password, string fullname, string email) {
            return base.Channel.CreateAccountAsync(password, fullname, email);
        }
        
        public System.Data.DataTable ViewProjectTheme() {
            return base.Channel.ViewProjectTheme();
        }
        
        public System.Threading.Tasks.Task<System.Data.DataTable> ViewProjectThemeAsync() {
            return base.Channel.ViewProjectThemeAsync();
        }
        
        public bool DeleteProposal(int submissionid) {
            return base.Channel.DeleteProposal(submissionid);
        }
        
        public System.Threading.Tasks.Task<bool> DeleteProposalAsync(int submissionid) {
            return base.Channel.DeleteProposalAsync(submissionid);
        }
        
        public bool UpdateProposal(int submissionid, string proposal) {
            return base.Channel.UpdateProposal(submissionid, proposal);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateProposalAsync(int submissionid, string proposal) {
            return base.Channel.UpdateProposalAsync(submissionid, proposal);
        }
        
        public bool SubmitProposal(int userid, int themeid, string proposal) {
            return base.Channel.SubmitProposal(userid, themeid, proposal);
        }
        
        public System.Threading.Tasks.Task<bool> SubmitProposalAsync(int userid, int themeid, string proposal) {
            return base.Channel.SubmitProposalAsync(userid, themeid, proposal);
        }
    }
}
