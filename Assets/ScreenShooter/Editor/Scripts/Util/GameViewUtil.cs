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

using System;
using System.Reflection;
using UnityEditor;

namespace Borodar.ScreenShooter.Utils
{
    public static class GameViewUtil
    {
        private static readonly object _gameViewSizesInstance;
        private static readonly MethodInfo _getGroup;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        static GameViewUtil()
        {
            var sizesType = typeof (Editor).Assembly.GetType("UnityEditor.GameViewSizes");
            var singleType = typeof (ScriptableSingleton<>).MakeGenericType(sizesType);
            var instanceProp = singleType.GetProperty("instance");
            _getGroup = sizesType.GetMethod("GetGroup");
            _gameViewSizesInstance = instanceProp.GetValue(null, null);
        }

        //---------------------------------------------------------------------
        // Public
        //---------------------------------------------------------------------

        public static void SetSizeByIndex(int index)
        {
            var gameViewType = typeof (Editor).Assembly.GetType("UnityEditor.GameView");
            var gameViewWindow = EditorWindow.GetWindow(gameViewType);
            gameViewType.GetMethod("SizeSelectionCallback", BindingFlags.Public | BindingFlags.Instance).Invoke(gameViewWindow, new object[] { index, null });
        }

        public static void AddCustomSize(GameViewSizeType viewSizeType, GameViewSizeGroupType sizeGroupType, int width, int height, string text)
        {
            var group = GetGroup(sizeGroupType);
            var addCustomSize = _getGroup.ReturnType.GetMethod("AddCustomSize");
            var gameViewSize = typeof (Editor).Assembly.GetType("UnityEditor.GameViewSize");
            var gameViewSizeType = typeof (Editor).Assembly.GetType("UnityEditor.GameViewSizeType");
            var ctor = gameViewSize.GetConstructor(new Type[] {gameViewSizeType, typeof (int), typeof (int), typeof (string)});
            var newSize = ctor.Invoke(new object[] {(int) viewSizeType, width, height, text});
            addCustomSize.Invoke(group, new object[] {newSize});
        }

        public static void RemoveCustomSize(GameViewSizeGroupType sizeGroupType, int index)
        {
            var group = GetGroup(sizeGroupType);
            var addCustomSize = _getGroup.ReturnType.GetMethod("RemoveCustomSize");
            addCustomSize.Invoke(group, new object[] { index });
        }

        public static int FindSizeIndex(GameViewSizeGroupType sizeGroupType, string text)
        {
            var group = GetGroup(sizeGroupType);
            var getDisplayTexts = group.GetType().GetMethod("GetDisplayTexts");
            var displayTexts = getDisplayTexts.Invoke(group, null) as string[];
            for (var i = 0; i < displayTexts.Length; i++)
            {
                var display = displayTexts[i];
                // the text we get is "Name (W:H)" if the size has a name, or just "W:H" e.g. 16:9
                // so if we're querying a custom size text we substring to only get the name
                // You could see the outputs by just logging
                // Debug.Log(display);
                var pren = display.IndexOf('(');
                // -1 to remove the space that's before the prens. This is very implementation-depdenent
                if (pren != -1) display = display.Substring(0, pren - 1);
                if (display == text)
                    return i;
            }
            return -1;
        }

        public static int FindSizeIndex(GameViewSizeGroupType sizeGroupType, int width, int height)
        {
            var group = GetGroup(sizeGroupType);
            var groupType = group.GetType();
            var getBuiltinCount = groupType.GetMethod("GetBuiltinCount");
            var getCustomCount = groupType.GetMethod("GetCustomCount");
            var sizesCount = (int)getBuiltinCount.Invoke(group, null) + (int)getCustomCount.Invoke(group, null);
            var getGameViewSize = groupType.GetMethod("GetGameViewSize");
            var gvsType = getGameViewSize.ReturnType;
            var widthProp = gvsType.GetProperty("width");
            var heightProp = gvsType.GetProperty("height");
            var indexValue = new object[1];
            for (var i = 0; i < sizesCount; i++)
            {
                indexValue[0] = i;
                var size = getGameViewSize.Invoke(group, indexValue);
                var sizeWidth = (int)widthProp.GetValue(size, null);
                var sizeHeight = (int)heightProp.GetValue(size, null);
                if (sizeWidth == width && sizeHeight == height)
                    return i;
            }
            return -1;
        }

        public static bool IsSizeExist(GameViewSizeGroupType sizeGroupType, string text)
        {
            return FindSizeIndex(sizeGroupType, text) != -1;
        }

        public static bool IsSizeExist(GameViewSizeGroupType sizeGroupType, int width, int height)
        {
            return FindSizeIndex(sizeGroupType, width, height) != -1;
        }

        public static object GetGroup(GameViewSizeGroupType type)
        {
            return _getGroup.Invoke(_gameViewSizesInstance, new object[] {(int) type});
        }

        public static GameViewSizeGroupType GetCurrentGroupType()
        {
            var getCurrentGroupTypeProp = _gameViewSizesInstance.GetType().GetProperty("currentGroupType");
            return (GameViewSizeGroupType)(int)getCurrentGroupTypeProp.GetValue(_gameViewSizesInstance, null);
        }

        public static int GetCurrentSizeIndex()
        {
            var gameViewType = typeof(Editor).Assembly.GetType("UnityEditor.GameView");
            var selectedSizeIndexProp = gameViewType.GetProperty("selectedSizeIndex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            var gameViewWindow = EditorWindow.GetWindow(gameViewType);
            return (int) selectedSizeIndexProp.GetValue(gameViewWindow, null);
        }

        //---------------------------------------------------------------------
        // Nested
        //---------------------------------------------------------------------

        public enum GameViewSizeType
        {
            AspectRatio,
            FixedResolution
        }
    }
}