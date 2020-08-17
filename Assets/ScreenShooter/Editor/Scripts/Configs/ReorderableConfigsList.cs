/*
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 */

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;
using Format = Borodar.ScreenShooter.Configs.ScreenshotConfig.Format;

namespace Borodar.ScreenShooter.Configs
{
    public static class ReorderableConfigsList
    {
        private static readonly string[] _fileTypes = {"PNG", "JPG"};

        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        public static UnityEditorInternal.ReorderableList Create(List<ScreenshotConfig> configsList, GenericMenu.MenuFunction2 menuItemHandler)
        {
            var reorderableList = new UnityEditorInternal.ReorderableList(configsList, typeof (ScreenshotConfig), true, false, true, true);

            reorderableList.elementHeight = EditorGUIUtility.singleLineHeight + 4;
            reorderableList.drawElementCallback = (position, index, isActive, isFocused) =>
            {
                const float textWidth = 12f;
                const float dimensionWidth = 45f;
                const float typeWidth = 45f;
                const float space = 10f;

                var config = configsList[index];
                var nameWidth = position.width - space - textWidth - 2 * dimensionWidth - space - typeWidth;

                position.y += 2;
                position.width = nameWidth;
                position.height -= 4;
                config.Name = EditorGUI.TextField(position, config.Name);

                position.x += position.width + space;
                position.width = dimensionWidth;
                config.Width = EditorGUI.IntField(position, config.Width);

                position.x += position.width;
                position.width = textWidth;
                EditorGUI.LabelField(position, "x");

                position.x += position.width;
                position.width = dimensionWidth;
                config.Height = EditorGUI.IntField(position, config.Height);

                position.x += position.width + space;
                position.width = typeWidth;
                config.Type = (Format) EditorGUI.Popup(position, (int) config.Type, _fileTypes);
            };

            reorderableList.onAddDropdownCallback = (buttonRect, list) =>
            {
                var menu = new GenericMenu();

                menu.AddItem(new GUIContent("Custom"), false, menuItemHandler, new ScreenshotConfig("Custom", 777, 777, Format.PNG));
                menu.AddSeparator("");

                foreach (var config in PredefinedConfigs.Android)
                {
                    var label = "Android/" + config.Name + " (" + config.Width + "x" + config.Height + ")";
                    menu.AddItem(new GUIContent(label), false, menuItemHandler, config);
                }

                foreach (var config in PredefinedConfigs.iOS)
                {
                    var label = "iOS/" + config.Name + " (" + config.Width + "x" + config.Height + ")";
                    menu.AddItem(new GUIContent(label), false, menuItemHandler, config);
                }

                foreach (var config in PredefinedConfigs.Standalone)
                {
                    var label = "Standalone/" + config.Name + " (" + config.Width + "x" + config.Height + ")";
                    menu.AddItem(new GUIContent(label), false, menuItemHandler, config);
                }

                menu.ShowAsContext();
            };

            return reorderableList;
        }
    }
}