﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Ce code source a été automatiquement généré par Microsoft.VSDesigner, Version 4.0.30319.42000.
// 
#pragma warning disable 1591

namespace Agence1.ReferenceServiceDisponibilte {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="ConsulterDisponibiliteSoap", Namespace="http://tempuri.org/")]
    public partial class ConsulterDisponibilite : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback chercherDisponibiliteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public ConsulterDisponibilite() {
            this.Url = global::Agence1.Properties.Settings.Default.Agence1_ReferenceServiceDisponibilte_ConsulterDisponibilite;
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
        public event chercherDisponibiliteCompletedEventHandler chercherDisponibiliteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/chercherDisponibilite", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public Offre[] chercherDisponibilite(string login, string mdp, string dateDebut, string dateFin, int nbPersonne) {
            object[] results = this.Invoke("chercherDisponibilite", new object[] {
                        login,
                        mdp,
                        dateDebut,
                        dateFin,
                        nbPersonne});
            return ((Offre[])(results[0]));
        }
        
        /// <remarks/>
        public void chercherDisponibiliteAsync(string login, string mdp, string dateDebut, string dateFin, int nbPersonne) {
            this.chercherDisponibiliteAsync(login, mdp, dateDebut, dateFin, nbPersonne, null);
        }
        
        /// <remarks/>
        public void chercherDisponibiliteAsync(string login, string mdp, string dateDebut, string dateFin, int nbPersonne, object userState) {
            if ((this.chercherDisponibiliteOperationCompleted == null)) {
                this.chercherDisponibiliteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnchercherDisponibiliteOperationCompleted);
            }
            this.InvokeAsync("chercherDisponibilite", new object[] {
                        login,
                        mdp,
                        dateDebut,
                        dateFin,
                        nbPersonne}, this.chercherDisponibiliteOperationCompleted, userState);
        }
        
        private void OnchercherDisponibiliteOperationCompleted(object arg) {
            if ((this.chercherDisponibiliteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.chercherDisponibiliteCompleted(this, new chercherDisponibiliteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
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
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class Offre {
        
        private string identifiantField;
        
        private TypeChambre typeChambreField;
        
        private string dateDisponibiliteField;
        
        private double prixField;
        
        /// <remarks/>
        public string Identifiant {
            get {
                return this.identifiantField;
            }
            set {
                this.identifiantField = value;
            }
        }
        
        /// <remarks/>
        public TypeChambre TypeChambre {
            get {
                return this.typeChambreField;
            }
            set {
                this.typeChambreField = value;
            }
        }
        
        /// <remarks/>
        public string DateDisponibilite {
            get {
                return this.dateDisponibiliteField;
            }
            set {
                this.dateDisponibiliteField = value;
            }
        }
        
        /// <remarks/>
        public double Prix {
            get {
                return this.prixField;
            }
            set {
                this.prixField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.4084.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://tempuri.org/")]
    public partial class TypeChambre {
        
        private int nbLitsField;
        
        /// <remarks/>
        public int NbLits {
            get {
                return this.nbLitsField;
            }
            set {
                this.nbLitsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    public delegate void chercherDisponibiliteCompletedEventHandler(object sender, chercherDisponibiliteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.8.4084.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class chercherDisponibiliteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal chercherDisponibiliteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public Offre[] Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((Offre[])(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591