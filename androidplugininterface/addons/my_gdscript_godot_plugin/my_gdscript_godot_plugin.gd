# Do not forget to add in `addons/my_gdscript_godot_plugin/` the `godotplugin-debug.aar` and `godotplugin-release.aar` files

@tool
extends EditorPlugin

var android_export_plugin: AndroidExportPlugin

func _enter_tree():
	android_export_plugin = AndroidExportPlugin.new()

	add_export_plugin(android_export_plugin)

func _exit_tree():
	remove_export_plugin(android_export_plugin)

	android_export_plugin = null

class AndroidExportPlugin extends EditorExportPlugin:
	var plugin_name = "MyGodotPlugin"
	
	func _supports_platform(platform):
		return platform is EditorExportPlatformAndroid
	
	func _get_android_libraries(platform, debug):
		if debug:
			return ["my_gdscript_godot_plugin/godotplugin-debug.aar"]
		return ["my_gdscript_godot_plugin/godotplugin-release.aar"]
	
#    func _get_android_dependencies(platform, debug):
#        return ["<group ID>:<artifact ID>:<major.minor.patch>"]
	
		
	func _get_name():
		return plugin_name
