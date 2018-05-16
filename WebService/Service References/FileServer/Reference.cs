﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebService.FileServer {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="FileServer.FileServerSoap")]
    public interface FileServerSoap {
        
        // CODEGEN: Generating message contract since element name cmd from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/run_cmd", ReplyAction="*")]
        WebService.FileServer.run_cmdResponse run_cmd(WebService.FileServer.run_cmdRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/run_cmd", ReplyAction="*")]
        System.Threading.Tasks.Task<WebService.FileServer.run_cmdResponse> run_cmdAsync(WebService.FileServer.run_cmdRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class run_cmdRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="run_cmd", Namespace="http://tempuri.org/", Order=0)]
        public WebService.FileServer.run_cmdRequestBody Body;
        
        public run_cmdRequest() {
        }
        
        public run_cmdRequest(WebService.FileServer.run_cmdRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class run_cmdRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string cmd;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string args;
        
        public run_cmdRequestBody() {
        }
        
        public run_cmdRequestBody(string cmd, string args) {
            this.cmd = cmd;
            this.args = args;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class run_cmdResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="run_cmdResponse", Namespace="http://tempuri.org/", Order=0)]
        public WebService.FileServer.run_cmdResponseBody Body;
        
        public run_cmdResponse() {
        }
        
        public run_cmdResponse(WebService.FileServer.run_cmdResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class run_cmdResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string run_cmdResult;
        
        public run_cmdResponseBody() {
        }
        
        public run_cmdResponseBody(string run_cmdResult) {
            this.run_cmdResult = run_cmdResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FileServerSoapChannel : WebService.FileServer.FileServerSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FileServerSoapClient : System.ServiceModel.ClientBase<WebService.FileServer.FileServerSoap>, WebService.FileServer.FileServerSoap {
        
        public FileServerSoapClient() {
        }
        
        public FileServerSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public FileServerSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileServerSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public FileServerSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WebService.FileServer.run_cmdResponse WebService.FileServer.FileServerSoap.run_cmd(WebService.FileServer.run_cmdRequest request) {
            return base.Channel.run_cmd(request);
        }
        
        public string run_cmd(string cmd, string args) {
            WebService.FileServer.run_cmdRequest inValue = new WebService.FileServer.run_cmdRequest();
            inValue.Body = new WebService.FileServer.run_cmdRequestBody();
            inValue.Body.cmd = cmd;
            inValue.Body.args = args;
            WebService.FileServer.run_cmdResponse retVal = ((WebService.FileServer.FileServerSoap)(this)).run_cmd(inValue);
            return retVal.Body.run_cmdResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<WebService.FileServer.run_cmdResponse> WebService.FileServer.FileServerSoap.run_cmdAsync(WebService.FileServer.run_cmdRequest request) {
            return base.Channel.run_cmdAsync(request);
        }
        
        public System.Threading.Tasks.Task<WebService.FileServer.run_cmdResponse> run_cmdAsync(string cmd, string args) {
            WebService.FileServer.run_cmdRequest inValue = new WebService.FileServer.run_cmdRequest();
            inValue.Body = new WebService.FileServer.run_cmdRequestBody();
            inValue.Body.cmd = cmd;
            inValue.Body.args = args;
            return ((WebService.FileServer.FileServerSoap)(this)).run_cmdAsync(inValue);
        }
    }
}
