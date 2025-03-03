// Remember that you first need to compile the C# code from Godot Engine (Project Build: Alt+B) and only then 
// the Godot Engine will allow you to enable the C# plugin.

// Do not forget to add in `addons/MyGodotPlugin/` the `godotplugin-debug.aar` and `godotplugin-release.aar` files

#if TOOLS
using Godot;

[Tool]
public partial class MyGodotPlugin : EditorPlugin
{
	public AndroidExportPlugin androidExportPlugin;
	public override void _EnterTree()
	{
		androidExportPlugin = new AndroidExportPlugin();

		AddExportPlugin(androidExportPlugin);
	}

	public override void _ExitTree()
	{
		RemoveExportPlugin(androidExportPlugin);

		androidExportPlugin = null;
	}
}

[Tool]
public partial class AndroidExportPlugin : EditorExportPlugin
{
	private string pluginName = "MyGodotPlugin";

	public override bool _SupportsPlatform(EditorExportPlatform platform)
	{
		return platform is EditorExportPlatformAndroid;
	}

	public override string[] _GetAndroidLibraries(EditorExportPlatform platform, bool debug)
	{
		return debug ? new string[] { "MyGodotPlugin/godotplugin-debug.aar" } : new string[] { "MyGodotPlugin/godotplugin-release.aar" };
	}

	// public virtual string[] _GetAndroidDependencies(EditorExportPlatform platform, bool debug)
	// {
	//     return new string[] {"<group ID>:<artifact ID>: <major.minor.patch>"};
	// }

	public override string _GetName()
	{
		return pluginName;
	}
}

#endif
