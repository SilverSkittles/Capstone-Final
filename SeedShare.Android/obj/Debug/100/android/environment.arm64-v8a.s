	.arch	armv8-a
	.file	"environment.arm64-v8a.arm64-v8a.s"
	.section	.rodata.env.str.1,"aMS",@progbits,1
	.type	.L.env.str.1, @object
.L.env.str.1:
	.asciz	"com.companyname.seedshare"
	.size	.L.env.str.1, 26
	.section	.data.application_config,"aw",@progbits
	.type	application_config, @object
	.p2align	3
	.global	application_config
application_config:
	/* uses_mono_llvm */
	.byte	0
	/* uses_mono_aot */
	.byte	0
	/* uses_assembly_preload */
	.byte	1
	/* is_a_bundled_app */
	.byte	0
	/* broken_exception_transitions */
	.byte	0
	/* instant_run_enabled */
	.byte	0
	/* jni_add_native_method_registration_attribute_present */
	.byte	0
	/* bound_exception_type */
	.byte	1
	/* package_naming_policy */
	.word	3
	/* environment_variable_count */
	.word	58
	/* system_property_count */
	.word	8
	/* android_package_name */
	.zero	4
	.xword	.L.env.str.1
	.size	application_config, 32
	.section	.rodata.env.str.2,"aMS",@progbits,1
	.type	.L.env.str.2, @object
.L.env.str.2:
	.asciz	"none"
	.size	.L.env.str.2, 5
	.section	.data.mono_aot_mode_name,"aw",@progbits
	.global	mono_aot_mode_name
mono_aot_mode_name:
	.xword	.L.env.str.2
	.section	.rodata.env.str.3,"aMS",@progbits,1
	.type	.L.env.str.3, @object
.L.env.str.3:
	.asciz	"//"
	.size	.L.env.str.3, 3
	.section	.rodata.env.str.4,"aMS",@progbits,1
	.type	.L.env.str.4, @object
.L.env.str.4:
	.asciz	""
	.size	.L.env.str.4, 1
	.section	.rodata.env.str.5,"aMS",@progbits,1
	.type	.L.env.str.5, @object
.L.env.str.5:
	.asciz	"//      Build Number"
	.size	.L.env.str.5, 21
	.section	.rodata.env.str.6,"aMS",@progbits,1
	.type	.L.env.str.6, @object
.L.env.str.6:
	.asciz	""
	.size	.L.env.str.6, 1
	.section	.rodata.env.str.7,"aMS",@progbits,1
	.type	.L.env.str.7, @object
.L.env.str.7:
	.asciz	"//      Major Version"
	.size	.L.env.str.7, 22
	.section	.rodata.env.str.8,"aMS",@progbits,1
	.type	.L.env.str.8, @object
.L.env.str.8:
	.asciz	""
	.size	.L.env.str.8, 1
	.section	.rodata.env.str.9,"aMS",@progbits,1
	.type	.L.env.str.9, @object
.L.env.str.9:
	.asciz	"//      Minor Version"
	.size	.L.env.str.9, 22
	.section	.rodata.env.str.10,"aMS",@progbits,1
	.type	.L.env.str.10, @object
.L.env.str.10:
	.asciz	""
	.size	.L.env.str.10, 1
	.section	.rodata.env.str.11,"aMS",@progbits,1
	.type	.L.env.str.11, @object
.L.env.str.11:
	.asciz	"//      Revision"
	.size	.L.env.str.11, 17
	.section	.rodata.env.str.12,"aMS",@progbits,1
	.type	.L.env.str.12, @object
.L.env.str.12:
	.asciz	""
	.size	.L.env.str.12, 1
	.section	.rodata.env.str.13,"aMS",@progbits,1
	.type	.L.env.str.13, @object
.L.env.str.13:
	.asciz	"// Add some common permissions, these can be removed if not needed"
	.size	.L.env.str.13, 67
	.section	.rodata.env.str.14,"aMS",@progbits,1
	.type	.L.env.str.14, @object
.L.env.str.14:
	.asciz	""
	.size	.L.env.str.14, 1
	.section	.rodata.env.str.15,"aMS",@progbits,1
	.type	.L.env.str.15, @object
.L.env.str.15:
	.asciz	"// General Information about an assembly is controlled through the following"
	.size	.L.env.str.15, 77
	.section	.rodata.env.str.16,"aMS",@progbits,1
	.type	.L.env.str.16, @object
.L.env.str.16:
	.asciz	""
	.size	.L.env.str.16, 1
	.section	.rodata.env.str.17,"aMS",@progbits,1
	.type	.L.env.str.17, @object
.L.env.str.17:
	.asciz	"// Version information for an assembly consists of the following four values:"
	.size	.L.env.str.17, 78
	.section	.rodata.env.str.18,"aMS",@progbits,1
	.type	.L.env.str.18, @object
.L.env.str.18:
	.asciz	""
	.size	.L.env.str.18, 1
	.section	.rodata.env.str.19,"aMS",@progbits,1
	.type	.L.env.str.19, @object
.L.env.str.19:
	.asciz	"// associated with an assembly."
	.size	.L.env.str.19, 32
	.section	.rodata.env.str.20,"aMS",@progbits,1
	.type	.L.env.str.20, @object
.L.env.str.20:
	.asciz	""
	.size	.L.env.str.20, 1
	.section	.rodata.env.str.21,"aMS",@progbits,1
	.type	.L.env.str.21, @object
.L.env.str.21:
	.asciz	"// set of attributes. Change these attribute values to modify the information"
	.size	.L.env.str.21, 78
	.section	.rodata.env.str.22,"aMS",@progbits,1
	.type	.L.env.str.22, @object
.L.env.str.22:
	.asciz	""
	.size	.L.env.str.22, 1
	.section	.rodata.env.str.23,"aMS",@progbits,1
	.type	.L.env.str.23, @object
.L.env.str.23:
	.asciz	"MONO_GC_PARAMS"
	.size	.L.env.str.23, 15
	.section	.rodata.env.str.24,"aMS",@progbits,1
	.type	.L.env.str.24, @object
.L.env.str.24:
	.asciz	"major=marksweep-conc"
	.size	.L.env.str.24, 21
	.section	.rodata.env.str.25,"aMS",@progbits,1
	.type	.L.env.str.25, @object
.L.env.str.25:
	.asciz	"MONO_LOG_LEVEL"
	.size	.L.env.str.25, 15
	.section	.rodata.env.str.26,"aMS",@progbits,1
	.type	.L.env.str.26, @object
.L.env.str.26:
	.asciz	"info"
	.size	.L.env.str.26, 5
	.section	.rodata.env.str.27,"aMS",@progbits,1
	.type	.L.env.str.27, @object
.L.env.str.27:
	.asciz	"XAMARIN_BUILD_ID"
	.size	.L.env.str.27, 17
	.section	.rodata.env.str.28,"aMS",@progbits,1
	.type	.L.env.str.28, @object
.L.env.str.28:
	.asciz	"0a6d8044-bd0c-4316-a81d-1f9ceec8b786"
	.size	.L.env.str.28, 37
	.section	.rodata.env.str.29,"aMS",@progbits,1
	.type	.L.env.str.29, @object
.L.env.str.29:
	.asciz	"XA_HTTP_CLIENT_HANDLER_TYPE"
	.size	.L.env.str.29, 28
	.section	.rodata.env.str.30,"aMS",@progbits,1
	.type	.L.env.str.30, @object
.L.env.str.30:
	.asciz	"Xamarin.Android.Net.AndroidClientHandler"
	.size	.L.env.str.30, 41
	.section	.rodata.env.str.31,"aMS",@progbits,1
	.type	.L.env.str.31, @object
.L.env.str.31:
	.asciz	"XA_TLS_PROVIDER"
	.size	.L.env.str.31, 16
	.section	.rodata.env.str.32,"aMS",@progbits,1
	.type	.L.env.str.32, @object
.L.env.str.32:
	.asciz	"btls"
	.size	.L.env.str.32, 5
	.section	.rodata.env.str.33,"aMS",@progbits,1
	.type	.L.env.str.33, @object
.L.env.str.33:
	.asciz	"[assembly: AssemblyCompany(\"\")]"
	.size	.L.env.str.33, 34
	.section	.rodata.env.str.34,"aMS",@progbits,1
	.type	.L.env.str.34, @object
.L.env.str.34:
	.asciz	""
	.size	.L.env.str.34, 1
	.section	.rodata.env.str.35,"aMS",@progbits,1
	.type	.L.env.str.35, @object
.L.env.str.35:
	.asciz	"[assembly: AssemblyConfiguration(\"\")]"
	.size	.L.env.str.35, 40
	.section	.rodata.env.str.36,"aMS",@progbits,1
	.type	.L.env.str.36, @object
.L.env.str.36:
	.asciz	""
	.size	.L.env.str.36, 1
	.section	.rodata.env.str.37,"aMS",@progbits,1
	.type	.L.env.str.37, @object
.L.env.str.37:
	.asciz	"[assembly: AssemblyCopyright(\"Copyright ©  2014\")]"
	.size	.L.env.str.37, 53
	.section	.rodata.env.str.38,"aMS",@progbits,1
	.type	.L.env.str.38, @object
.L.env.str.38:
	.asciz	""
	.size	.L.env.str.38, 1
	.section	.rodata.env.str.39,"aMS",@progbits,1
	.type	.L.env.str.39, @object
.L.env.str.39:
	.asciz	"[assembly: AssemblyCulture(\"\")]"
	.size	.L.env.str.39, 34
	.section	.rodata.env.str.40,"aMS",@progbits,1
	.type	.L.env.str.40, @object
.L.env.str.40:
	.asciz	""
	.size	.L.env.str.40, 1
	.section	.rodata.env.str.41,"aMS",@progbits,1
	.type	.L.env.str.41, @object
.L.env.str.41:
	.asciz	"[assembly: AssemblyDescription(\"\")]"
	.size	.L.env.str.41, 38
	.section	.rodata.env.str.42,"aMS",@progbits,1
	.type	.L.env.str.42, @object
.L.env.str.42:
	.asciz	""
	.size	.L.env.str.42, 1
	.section	.rodata.env.str.43,"aMS",@progbits,1
	.type	.L.env.str.43, @object
.L.env.str.43:
	.asciz	"[assembly: AssemblyFileVersion(\"1.0.0.0\")]"
	.size	.L.env.str.43, 45
	.section	.rodata.env.str.44,"aMS",@progbits,1
	.type	.L.env.str.44, @object
.L.env.str.44:
	.asciz	""
	.size	.L.env.str.44, 1
	.section	.rodata.env.str.45,"aMS",@progbits,1
	.type	.L.env.str.45, @object
.L.env.str.45:
	.asciz	"[assembly: AssemblyProduct(\"SeedShare.Android\")]"
	.size	.L.env.str.45, 51
	.section	.rodata.env.str.46,"aMS",@progbits,1
	.type	.L.env.str.46, @object
.L.env.str.46:
	.asciz	""
	.size	.L.env.str.46, 1
	.section	.rodata.env.str.47,"aMS",@progbits,1
	.type	.L.env.str.47, @object
.L.env.str.47:
	.asciz	"[assembly: AssemblyTitle(\"SeedShare.Android\")]"
	.size	.L.env.str.47, 49
	.section	.rodata.env.str.48,"aMS",@progbits,1
	.type	.L.env.str.48, @object
.L.env.str.48:
	.asciz	""
	.size	.L.env.str.48, 1
	.section	.rodata.env.str.49,"aMS",@progbits,1
	.type	.L.env.str.49, @object
.L.env.str.49:
	.asciz	"[assembly: AssemblyTrademark(\"\")]"
	.size	.L.env.str.49, 36
	.section	.rodata.env.str.50,"aMS",@progbits,1
	.type	.L.env.str.50, @object
.L.env.str.50:
	.asciz	""
	.size	.L.env.str.50, 1
	.section	.rodata.env.str.51,"aMS",@progbits,1
	.type	.L.env.str.51, @object
.L.env.str.51:
	.asciz	"[assembly: AssemblyVersion(\"1.0.0.0\")]"
	.size	.L.env.str.51, 41
	.section	.rodata.env.str.52,"aMS",@progbits,1
	.type	.L.env.str.52, @object
.L.env.str.52:
	.asciz	""
	.size	.L.env.str.52, 1
	.section	.rodata.env.str.53,"aMS",@progbits,1
	.type	.L.env.str.53, @object
.L.env.str.53:
	.asciz	"[assembly: ComVisible(false)]"
	.size	.L.env.str.53, 30
	.section	.rodata.env.str.54,"aMS",@progbits,1
	.type	.L.env.str.54, @object
.L.env.str.54:
	.asciz	""
	.size	.L.env.str.54, 1
	.section	.rodata.env.str.55,"aMS",@progbits,1
	.type	.L.env.str.55, @object
.L.env.str.55:
	.asciz	"[assembly: UsesPermission(Android.Manifest.Permission.Internet)]"
	.size	.L.env.str.55, 65
	.section	.rodata.env.str.56,"aMS",@progbits,1
	.type	.L.env.str.56, @object
.L.env.str.56:
	.asciz	""
	.size	.L.env.str.56, 1
	.section	.rodata.env.str.57,"aMS",@progbits,1
	.type	.L.env.str.57, @object
.L.env.str.57:
	.asciz	"[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]"
	.size	.L.env.str.57, 77
	.section	.rodata.env.str.58,"aMS",@progbits,1
	.type	.L.env.str.58, @object
.L.env.str.58:
	.asciz	""
	.size	.L.env.str.58, 1
	.section	.rodata.env.str.59,"aMS",@progbits,1
	.type	.L.env.str.59, @object
.L.env.str.59:
	.asciz	"__XA_PACKAGE_NAMING_POLICY__"
	.size	.L.env.str.59, 29
	.section	.rodata.env.str.60,"aMS",@progbits,1
	.type	.L.env.str.60, @object
.L.env.str.60:
	.asciz	"LowercaseCrc64"
	.size	.L.env.str.60, 15
	.section	.data.app_environment_variables,"aw",@progbits
	.type	app_environment_variables, @object
	.p2align	3
	.global	app_environment_variables
app_environment_variables:
	.xword	.L.env.str.3
	.xword	.L.env.str.4
	.xword	.L.env.str.5
	.xword	.L.env.str.6
	.xword	.L.env.str.7
	.xword	.L.env.str.8
	.xword	.L.env.str.9
	.xword	.L.env.str.10
	.xword	.L.env.str.11
	.xword	.L.env.str.12
	.xword	.L.env.str.13
	.xword	.L.env.str.14
	.xword	.L.env.str.15
	.xword	.L.env.str.16
	.xword	.L.env.str.17
	.xword	.L.env.str.18
	.xword	.L.env.str.19
	.xword	.L.env.str.20
	.xword	.L.env.str.21
	.xword	.L.env.str.22
	.xword	.L.env.str.23
	.xword	.L.env.str.24
	.xword	.L.env.str.25
	.xword	.L.env.str.26
	.xword	.L.env.str.27
	.xword	.L.env.str.28
	.xword	.L.env.str.29
	.xword	.L.env.str.30
	.xword	.L.env.str.31
	.xword	.L.env.str.32
	.xword	.L.env.str.33
	.xword	.L.env.str.34
	.xword	.L.env.str.35
	.xword	.L.env.str.36
	.xword	.L.env.str.37
	.xword	.L.env.str.38
	.xword	.L.env.str.39
	.xword	.L.env.str.40
	.xword	.L.env.str.41
	.xword	.L.env.str.42
	.xword	.L.env.str.43
	.xword	.L.env.str.44
	.xword	.L.env.str.45
	.xword	.L.env.str.46
	.xword	.L.env.str.47
	.xword	.L.env.str.48
	.xword	.L.env.str.49
	.xword	.L.env.str.50
	.xword	.L.env.str.51
	.xword	.L.env.str.52
	.xword	.L.env.str.53
	.xword	.L.env.str.54
	.xword	.L.env.str.55
	.xword	.L.env.str.56
	.xword	.L.env.str.57
	.xword	.L.env.str.58
	.xword	.L.env.str.59
	.xword	.L.env.str.60
	.size	app_environment_variables, 464
	.section	.rodata.env.str.61,"aMS",@progbits,1
	.type	.L.env.str.61, @object
.L.env.str.61:
	.asciz	"using Android.App;"
	.size	.L.env.str.61, 19
	.section	.rodata.env.str.62,"aMS",@progbits,1
	.type	.L.env.str.62, @object
.L.env.str.62:
	.asciz	""
	.size	.L.env.str.62, 1
	.section	.rodata.env.str.63,"aMS",@progbits,1
	.type	.L.env.str.63, @object
.L.env.str.63:
	.asciz	"using System.Reflection;"
	.size	.L.env.str.63, 25
	.section	.rodata.env.str.64,"aMS",@progbits,1
	.type	.L.env.str.64, @object
.L.env.str.64:
	.asciz	""
	.size	.L.env.str.64, 1
	.section	.rodata.env.str.65,"aMS",@progbits,1
	.type	.L.env.str.65, @object
.L.env.str.65:
	.asciz	"using System.Runtime.CompilerServices;"
	.size	.L.env.str.65, 39
	.section	.rodata.env.str.66,"aMS",@progbits,1
	.type	.L.env.str.66, @object
.L.env.str.66:
	.asciz	""
	.size	.L.env.str.66, 1
	.section	.rodata.env.str.67,"aMS",@progbits,1
	.type	.L.env.str.67, @object
.L.env.str.67:
	.asciz	"using System.Runtime.InteropServices;"
	.size	.L.env.str.67, 38
	.section	.rodata.env.str.68,"aMS",@progbits,1
	.type	.L.env.str.68, @object
.L.env.str.68:
	.asciz	""
	.size	.L.env.str.68, 1
	.section	.data.app_system_properties,"aw",@progbits
	.type	app_system_properties, @object
	.p2align	3
	.global	app_system_properties
app_system_properties:
	.xword	.L.env.str.61
	.xword	.L.env.str.62
	.xword	.L.env.str.63
	.xword	.L.env.str.64
	.xword	.L.env.str.65
	.xword	.L.env.str.66
	.xword	.L.env.str.67
	.xword	.L.env.str.68
	.size	app_system_properties, 64
