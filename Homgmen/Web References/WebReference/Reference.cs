﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

// 
// 此源代码是由 Microsoft.VSDesigner 4.0.30319.42000 版自动生成。
// 
#pragma warning disable 1591

namespace Homgmen.WebReference {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="TransitServiceSoap11Binding", Namespace="http://impl.com.cn")]
    public partial class TransitService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback writeUuidOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetInfo2OperationCompleted;
        
        private System.Threading.SendOrPostCallback SetDocumentOtherOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetDocumentOperationCompleted;
        
        private System.Threading.SendOrPostCallback transPortOperationOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetGroupInfoOperationCompleted;
        
        private System.Threading.SendOrPostCallback isFileExistsOperationCompleted;
        
        private System.Threading.SendOrPostCallback GetDESKeyOperationCompleted;
        
        private System.Threading.SendOrPostCallback SetInfoOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public TransitService() {
            this.Url = global::Homgmen.Properties.Settings.Default.Homgmen_WebReference_TransitService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event writeUuidCompletedEventHandler writeUuidCompleted;
        
        /// <remarks/>
        public event SetInfo2CompletedEventHandler SetInfo2Completed;
        
        /// <remarks/>
        public event SetDocumentOtherCompletedEventHandler SetDocumentOtherCompleted;
        
        /// <remarks/>
        public event SetDocumentCompletedEventHandler SetDocumentCompleted;
        
        /// <remarks/>
        public event transPortOperationCompletedEventHandler transPortOperationCompleted;
        
        /// <remarks/>
        public event SetGroupInfoCompletedEventHandler SetGroupInfoCompleted;
        
        /// <remarks/>
        public event isFileExistsCompletedEventHandler isFileExistsCompleted;
        
        /// <remarks/>
        public event GetDESKeyCompletedEventHandler GetDESKeyCompleted;
        
        /// <remarks/>
        public event SetInfoCompletedEventHandler SetInfoCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:writeUuid", RequestNamespace="http://impl.com.cn", OneWay=true, Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void writeUuid([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string @string) {
            this.Invoke("writeUuid", new object[] {
                        @string});
        }
        
        /// <remarks/>
        public void writeUuidAsync(string @string) {
            this.writeUuidAsync(@string, null);
        }
        
        /// <remarks/>
        public void writeUuidAsync(string @string, object userState) {
            if ((this.writeUuidOperationCompleted == null)) {
                this.writeUuidOperationCompleted = new System.Threading.SendOrPostCallback(this.OnwriteUuidOperationCompleted);
            }
            this.InvokeAsync("writeUuid", new object[] {
                        @string}, this.writeUuidOperationCompleted, userState);
        }
        
        private void OnwriteUuidOperationCompleted(object arg) {
            if ((this.writeUuidCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.writeUuidCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:SetInfo2", RequestNamespace="http://impl.com.cn", OneWay=true, Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SetInfo2([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string receiveinfo, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string loaninfo, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string comCode) {
            this.Invoke("SetInfo2", new object[] {
                        receiveinfo,
                        loaninfo,
                        comCode});
        }
        
        /// <remarks/>
        public void SetInfo2Async(string receiveinfo, string loaninfo, string comCode) {
            this.SetInfo2Async(receiveinfo, loaninfo, comCode, null);
        }
        
        /// <remarks/>
        public void SetInfo2Async(string receiveinfo, string loaninfo, string comCode, object userState) {
            if ((this.SetInfo2OperationCompleted == null)) {
                this.SetInfo2OperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetInfo2OperationCompleted);
            }
            this.InvokeAsync("SetInfo2", new object[] {
                        receiveinfo,
                        loaninfo,
                        comCode}, this.SetInfo2OperationCompleted, userState);
        }
        
        private void OnSetInfo2OperationCompleted(object arg) {
            if ((this.SetInfo2Completed != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetInfo2Completed(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:SetDocumentOther", RequestNamespace="http://impl.com.cn", ResponseNamespace="http://impl.com.cn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string SetDocumentOther([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string info, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string comCode) {
            object[] results = this.Invoke("SetDocumentOther", new object[] {
                        info,
                        comCode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void SetDocumentOtherAsync(string info, string comCode) {
            this.SetDocumentOtherAsync(info, comCode, null);
        }
        
        /// <remarks/>
        public void SetDocumentOtherAsync(string info, string comCode, object userState) {
            if ((this.SetDocumentOtherOperationCompleted == null)) {
                this.SetDocumentOtherOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetDocumentOtherOperationCompleted);
            }
            this.InvokeAsync("SetDocumentOther", new object[] {
                        info,
                        comCode}, this.SetDocumentOtherOperationCompleted, userState);
        }
        
        private void OnSetDocumentOtherOperationCompleted(object arg) {
            if ((this.SetDocumentOtherCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetDocumentOtherCompleted(this, new SetDocumentOtherCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:SetDocument", RequestNamespace="http://impl.com.cn", OneWay=true, Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SetDocument([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string info, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string comCode) {
            this.Invoke("SetDocument", new object[] {
                        info,
                        comCode});
        }
        
        /// <remarks/>
        public void SetDocumentAsync(string info, string comCode) {
            this.SetDocumentAsync(info, comCode, null);
        }
        
        /// <remarks/>
        public void SetDocumentAsync(string info, string comCode, object userState) {
            if ((this.SetDocumentOperationCompleted == null)) {
                this.SetDocumentOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetDocumentOperationCompleted);
            }
            this.InvokeAsync("SetDocument", new object[] {
                        info,
                        comCode}, this.SetDocumentOperationCompleted, userState);
        }
        
        private void OnSetDocumentOperationCompleted(object arg) {
            if ((this.SetDocumentCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetDocumentCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:transPortOperation", RequestNamespace="http://impl.com.cn", ResponseNamespace="http://impl.com.cn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string transPortOperation([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string condition) {
            object[] results = this.Invoke("transPortOperation", new object[] {
                        condition});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void transPortOperationAsync(string condition) {
            this.transPortOperationAsync(condition, null);
        }
        
        /// <remarks/>
        public void transPortOperationAsync(string condition, object userState) {
            if ((this.transPortOperationOperationCompleted == null)) {
                this.transPortOperationOperationCompleted = new System.Threading.SendOrPostCallback(this.OntransPortOperationOperationCompleted);
            }
            this.InvokeAsync("transPortOperation", new object[] {
                        condition}, this.transPortOperationOperationCompleted, userState);
        }
        
        private void OntransPortOperationOperationCompleted(object arg) {
            if ((this.transPortOperationCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.transPortOperationCompleted(this, new transPortOperationCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:SetGroupInfo", RequestNamespace="http://impl.com.cn", OneWay=true, Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SetGroupInfo([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string info, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string comCode) {
            this.Invoke("SetGroupInfo", new object[] {
                        info,
                        comCode});
        }
        
        /// <remarks/>
        public void SetGroupInfoAsync(string info, string comCode) {
            this.SetGroupInfoAsync(info, comCode, null);
        }
        
        /// <remarks/>
        public void SetGroupInfoAsync(string info, string comCode, object userState) {
            if ((this.SetGroupInfoOperationCompleted == null)) {
                this.SetGroupInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetGroupInfoOperationCompleted);
            }
            this.InvokeAsync("SetGroupInfo", new object[] {
                        info,
                        comCode}, this.SetGroupInfoOperationCompleted, userState);
        }
        
        private void OnSetGroupInfoOperationCompleted(object arg) {
            if ((this.SetGroupInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetGroupInfoCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:isFileExists", RequestNamespace="http://impl.com.cn", ResponseNamespace="http://impl.com.cn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string isFileExists([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] File file, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string comcode) {
            object[] results = this.Invoke("isFileExists", new object[] {
                        file,
                        comcode});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void isFileExistsAsync(File file, string comcode) {
            this.isFileExistsAsync(file, comcode, null);
        }
        
        /// <remarks/>
        public void isFileExistsAsync(File file, string comcode, object userState) {
            if ((this.isFileExistsOperationCompleted == null)) {
                this.isFileExistsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnisFileExistsOperationCompleted);
            }
            this.InvokeAsync("isFileExists", new object[] {
                        file,
                        comcode}, this.isFileExistsOperationCompleted, userState);
        }
        
        private void OnisFileExistsOperationCompleted(object arg) {
            if ((this.isFileExistsCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.isFileExistsCompleted(this, new isFileExistsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:GetDESKey", RequestNamespace="http://impl.com.cn", ResponseNamespace="http://impl.com.cn", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        [return: System.Xml.Serialization.XmlElementAttribute("return", IsNullable=true)]
        public string GetDESKey([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string info) {
            object[] results = this.Invoke("GetDESKey", new object[] {
                        info});
            return ((string)(results[0]));
        }
        
        /// <remarks/>
        public void GetDESKeyAsync(string info) {
            this.GetDESKeyAsync(info, null);
        }
        
        /// <remarks/>
        public void GetDESKeyAsync(string info, object userState) {
            if ((this.GetDESKeyOperationCompleted == null)) {
                this.GetDESKeyOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetDESKeyOperationCompleted);
            }
            this.InvokeAsync("GetDESKey", new object[] {
                        info}, this.GetDESKeyOperationCompleted, userState);
        }
        
        private void OnGetDESKeyOperationCompleted(object arg) {
            if ((this.GetDESKeyCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetDESKeyCompleted(this, new GetDESKeyCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("urn:SetInfo", RequestNamespace="http://impl.com.cn", OneWay=true, Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void SetInfo([System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string receiveinfo, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string loaninfo, [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)] string comCode) {
            this.Invoke("SetInfo", new object[] {
                        receiveinfo,
                        loaninfo,
                        comCode});
        }
        
        /// <remarks/>
        public void SetInfoAsync(string receiveinfo, string loaninfo, string comCode) {
            this.SetInfoAsync(receiveinfo, loaninfo, comCode, null);
        }
        
        /// <remarks/>
        public void SetInfoAsync(string receiveinfo, string loaninfo, string comCode, object userState) {
            if ((this.SetInfoOperationCompleted == null)) {
                this.SetInfoOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSetInfoOperationCompleted);
            }
            this.InvokeAsync("SetInfo", new object[] {
                        receiveinfo,
                        loaninfo,
                        comCode}, this.SetInfoOperationCompleted, userState);
        }
        
        private void OnSetInfoOperationCompleted(object arg) {
            if ((this.SetInfoCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SetInfoCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1064.2")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://io.java/xsd")]
    public partial class File {
        
        private bool absoluteField;
        
        private bool absoluteFieldSpecified;
        
        private File absoluteFileField;
        
        private string absolutePathField;
        
        private File canonicalFileField;
        
        private string canonicalPathField;
        
        private bool directoryField;
        
        private bool directoryFieldSpecified;
        
        private bool fileField;
        
        private bool fileFieldSpecified;
        
        private long freeSpaceField;
        
        private bool freeSpaceFieldSpecified;
        
        private bool hiddenField;
        
        private bool hiddenFieldSpecified;
        
        private string nameField;
        
        private string parentField;
        
        private File parentFileField;
        
        private string pathField;
        
        private long totalSpaceField;
        
        private bool totalSpaceFieldSpecified;
        
        private long usableSpaceField;
        
        private bool usableSpaceFieldSpecified;
        
        /// <remarks/>
        public bool absolute {
            get {
                return this.absoluteField;
            }
            set {
                this.absoluteField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool absoluteSpecified {
            get {
                return this.absoluteFieldSpecified;
            }
            set {
                this.absoluteFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public File absoluteFile {
            get {
                return this.absoluteFileField;
            }
            set {
                this.absoluteFileField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string absolutePath {
            get {
                return this.absolutePathField;
            }
            set {
                this.absolutePathField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public File canonicalFile {
            get {
                return this.canonicalFileField;
            }
            set {
                this.canonicalFileField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string canonicalPath {
            get {
                return this.canonicalPathField;
            }
            set {
                this.canonicalPathField = value;
            }
        }
        
        /// <remarks/>
        public bool directory {
            get {
                return this.directoryField;
            }
            set {
                this.directoryField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool directorySpecified {
            get {
                return this.directoryFieldSpecified;
            }
            set {
                this.directoryFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool file {
            get {
                return this.fileField;
            }
            set {
                this.fileField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool fileSpecified {
            get {
                return this.fileFieldSpecified;
            }
            set {
                this.fileFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public long freeSpace {
            get {
                return this.freeSpaceField;
            }
            set {
                this.freeSpaceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool freeSpaceSpecified {
            get {
                return this.freeSpaceFieldSpecified;
            }
            set {
                this.freeSpaceFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool hidden {
            get {
                return this.hiddenField;
            }
            set {
                this.hiddenField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool hiddenSpecified {
            get {
                return this.hiddenFieldSpecified;
            }
            set {
                this.hiddenFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string parent {
            get {
                return this.parentField;
            }
            set {
                this.parentField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public File parentFile {
            get {
                return this.parentFileField;
            }
            set {
                this.parentFileField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string path {
            get {
                return this.pathField;
            }
            set {
                this.pathField = value;
            }
        }
        
        /// <remarks/>
        public long totalSpace {
            get {
                return this.totalSpaceField;
            }
            set {
                this.totalSpaceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool totalSpaceSpecified {
            get {
                return this.totalSpaceFieldSpecified;
            }
            set {
                this.totalSpaceFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public long usableSpace {
            get {
                return this.usableSpaceField;
            }
            set {
                this.usableSpaceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool usableSpaceSpecified {
            get {
                return this.usableSpaceFieldSpecified;
            }
            set {
                this.usableSpaceFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void writeUuidCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void SetInfo2CompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void SetDocumentOtherCompletedEventHandler(object sender, SetDocumentOtherCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SetDocumentOtherCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal SetDocumentOtherCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void SetDocumentCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void transPortOperationCompletedEventHandler(object sender, transPortOperationCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class transPortOperationCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal transPortOperationCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void SetGroupInfoCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void isFileExistsCompletedEventHandler(object sender, isFileExistsCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class isFileExistsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal isFileExistsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void GetDESKeyCompletedEventHandler(object sender, GetDESKeyCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetDESKeyCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal GetDESKeyCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public string Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1038.0")]
    public delegate void SetInfoCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591