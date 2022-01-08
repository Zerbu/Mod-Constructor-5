Download the latest version from Releases: https://github.com/Zerbu/Mod-Constructor-5/releases

If you discover any bugs, please report them here: https://github.com/Zerbu/Mod-Constructor-5/issues

# The Sims 4 Mod Constructor V5
The Sims 4 Mod Constructor is a downloadable program that allows users to create mods for The Sims 4 in a user-friendly environment. The current (alpha) release supports traits, social interactions and custom whims. Version 5 is easier to use than ever!

## Changes from Version 4
* Every feature has its own UI! Features that were confusing in version 4 have been made to be more user friendly.
* This is the first version of Mod Constructor to support the creation of custom whims.
* You don't have to open a whole heep of tabs just to create one trait! The new UI includes inline editors that let you make changes to one element from inside the tab of another. (Note: You'll still need to open a separate tab for more complex changes, such as adding modifiers to a buff)
* The new Element Settings dialog allows you to change an element's technical ID (it's no longer tied to what you named the element when you first created it) and override the instance key to create default replacements. (Note: There is no UI for finding the IDs of existing resources, but this may be added in the future)
* Loot actions sets and broadcasters are easier to create. Instead of assigning a condition to an action, it's the other way around - and you can assign multiple actions to one condition. Better yet, you can create nested conditions, and Mod Constructor will automatically merge them on export.
* How related elements work has been simplified, and elements created outside the "Create Element" dialog are no longer dependant on the element they were created from. Instead, those elements are marked as "context specific". Context specific elements don't show in the sidebar, and will be deleted on export if they aren't referenced anywhere. Other than that, they behave just like normal elements, and you can convert a context specific element to a root element from Element Settings.
* Custom tuning has improved. Now there's a dedicated dialog that uses AvalonEdit for syntax highlighting, and a "Preview" feature that lets you see how the exported XML will look. Furthermore, if you include a hashtag symbol (#) followed by the ID of an element in the mod (for example: #MyCustomTrait), Mod Constructor will replace it with the instance key of that element when exporting.
* Because of past problems, all elements are exported with FNV32 instance keys. Since FNV64 tends to cause hidden bugs, and a future patch could cause even worse problems, FNV32 is the safest option.
* In general, improvements to how the code is organized will make it easier to add more features in the future.

## Download
### Release
**Download the latest version from Releases: https://github.com/Zerbu/Mod-Constructor-5/releases**

### Source Code
You can download the source code from this page. Mod Constructor V5 was last updated and compiled using Visual Studio 2022, so it's recommended you use that. If you decide to use an older version, or another program, you do so at your own risk. **If you have trouble getting it to compile, try changing the platform from "Any CPU" to "x64".**
