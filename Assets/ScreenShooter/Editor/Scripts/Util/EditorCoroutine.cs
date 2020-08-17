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

using System.Collections;
using UnityEditor;

namespace Borodar.ScreenShooter.Utils
{
    public class EditorCoroutine
    {
        //---------------------------------------------------------------------
        // Static
        //---------------------------------------------------------------------

        public static EditorCoroutine Start(IEnumerator _routine)
        {
            EditorCoroutine coroutine = new EditorCoroutine(_routine);
            coroutine.Start();
            return coroutine;
        }

        public static EditorCoroutine StartManual(IEnumerator _routine)
        {
            var coroutine = new EditorCoroutine(_routine);
            return coroutine;
        }

        //---------------------------------------------------------------------
        // Instance
        //---------------------------------------------------------------------

        private readonly IEnumerator _routine;

        private EditorCoroutine(IEnumerator routine)
        {
            _routine = routine;
        }

        protected void Start()
        {
            EditorApplication.update += Update;
        }
        protected void Stop()
        {
            EditorApplication.update -= Update;
        }

        protected void Update()
        {
            if (!_routine.MoveNext()) Stop();
        }
    }
}