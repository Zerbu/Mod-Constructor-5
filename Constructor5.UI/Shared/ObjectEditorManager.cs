using Constructor5.Core;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Constructor5.UI.Shared
{
    public static class ObjectEditorManager
    {
        internal static object CreateEditor(object obj, string category = "Default", string tag = null)
        {
            var dictionary = GetDictionary(category);
            if (dictionary == null)
            {
                return null;
            }

            if (!dictionary.TryGetValue(obj.GetType(), out var editorType))
            {
                return null;
            }

            var editor = (IObjectEditor)Reflection.CreateObject(editorType);
            editor.SetObject(obj, tag);
            return editor is UserControl ? editor : editor.Content;
        }

        public static bool HasEditor(object obj, string category = "Default")
        {
            var dictionary = GetDictionary(category);

            if (dictionary == null)
            {
                return false;
            }

            return dictionary.ContainsKey(obj.GetType());
        }

        public static void SetEditorType(Type objectType, Type editorType, string category = "Default") => GetDictionary(category).Add(objectType, editorType);

        private static Dictionary<Type, Type> GetDictionary(string category)
        {
            if (!EditorTypes.ContainsKey(category))
            {
                EditorTypes.Add(category, new Dictionary<Type, Type>());
            }

            return EditorTypes[category];
        }

        private static Dictionary<string, Dictionary<Type, Type>> EditorTypes { get; } = new Dictionary<string, Dictionary<Type, Type>>();
    }
}