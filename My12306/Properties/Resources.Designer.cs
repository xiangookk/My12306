﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace My12306.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("My12306.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似于 System.IO.MemoryStream 的 System.IO.UnmanagedMemoryStream 类型的本地化资源。
        /// </summary>
        internal static System.IO.UnmanagedMemoryStream message {
            get {
                return ResourceManager.GetStream("message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 bjb|北京北|VAP|beijingbei|bjb|0@bjd|北京东|BOP|beijingdong|bjd|1@bji|北京|BJP|beijing|bj|2@bjn|北京南|VNP|beijingnan|bjn|3@bjx|北京西|BXP|beijingxi|bjx|4@cqb|重庆北|CUW|chongqingbei|cqb|5@cqi|重庆|CQW|chongqing|cq|6@cqn|重庆南|CRW|chongqingnan|cqn|7@sha|上海|SHH|shanghai|sh|8@shn|上海南|SNH|shanghainan|shn|9@shq|上海虹桥|AOH|shanghaihongqiao|shhq|10@shx|上海西|SXH|shanghaixi|shx|11@tjb|天津北|TBP|tianjinbei|tjb|12@tji|天津|TJP|tianjin|tj|13@tjn|天津南|TIP|tianjinnan|tjn|14@tjx|天津西|TXP|tianjinxi|tjx|15@cch|长春|CCT|changchun|cc|16@ccn|长春南|CET|changchu [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string station_name {
            get {
                return ResourceManager.GetString("station_name", resourceCulture);
            }
        }
    }
}
