﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceLibrary.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"D:\\2011-2012\\Software analysis and des" +
            "ign\\Group-work\\Project_SVN\\1 Document\\Thao\\KFC Database\\KFC_DB.mdf\";Integrated S" +
            "ecurity=True;Connect Timeout=30;User Instance=True")]
        public string KFC_DBConnectionString {
            get {
                return ((string)(this["KFC_DBConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=.\\SQLEXPRESS;AttachDbFilename=\"D:\\1 CLASS STUDY\\1 Lecture\\1 Third yea" +
            "r\\1 Software Design\\5 Google Code\\1 Document\\Thao\\KFC Database\\KFC_DB4.mdf\";Inte" +
            "grated Security=True;Connect Timeout=30;User Instance=True")]
        public string KFC_DB4ConnectionString {
            get {
                return ((string)(this["KFC_DB4ConnectionString"]));
            }
        }
    }
}
