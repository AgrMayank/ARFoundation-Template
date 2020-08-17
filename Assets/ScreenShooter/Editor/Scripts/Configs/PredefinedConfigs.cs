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

namespace Borodar.ScreenShooter.Configs
{
    public class PredefinedConfigs
    {
        public static ScreenshotConfig[] Android =
        {
            new ScreenshotConfig("Nexus 4 Portrait", 768, 1280, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("Nexus 4 Landscape", 1280, 768, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("Nexus 5 Portrait", 1080, 1920, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("Nexus 5 Landscape", 1920, 1080, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("Nexus 6 Portrait", 1440, 2560, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("Nexus 6 Landscape", 2560, 1440, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("Nexus 7 Portrait", 800, 1280, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("Nexus 7 Landscape", 1280, 800, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("Nexus 7 (2013) Portrait", 1200, 1920, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("Nexus 7 (2013) Landscape", 1920, 1200, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("Nexus 10 Portrait", 1600, 2560, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("Nexus 10 Landscape", 2560, 1600, ScreenshotConfig.Format.PNG),
        };

        public static ScreenshotConfig[] iOS =
        {
            new ScreenshotConfig("iPhone 3.5-Inch Portrait", 640, 960, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("iPhone 3.5-Inch Landscape", 960, 640, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("iPhone 4-Inch Portrait", 640, 1136, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("iPhone 4-Inch Landscape", 1136, 640, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("iPhone 4.7-Inch Portrait", 750, 1334, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("iPhone 4.7-Inch Landscape", 1334, 750, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("iPhone 5.5-Inch Portrait", 1242, 2208, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("iPhone 5.5-Inch Landscape", 2208, 1242, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("iPad Portrait", 768, 1024, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("iPad Landscape", 1024, 768, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("iPad Hi-Res Portrait", 1536, 2048, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("iPad Hi-Res Landscape", 2048, 1536, ScreenshotConfig.Format.PNG),

            new ScreenshotConfig("iPad Pro Portrait", 2048, 2732, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("iPad Pro Landscape", 2732, 2048, ScreenshotConfig.Format.PNG)
        };

        public static ScreenshotConfig[] Standalone =
        {
            new ScreenshotConfig("XGA", 1024, 768, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("SXGA", 1280, 1024, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("WXGA", 1280, 800, ScreenshotConfig.Format.PNG),                        
            new ScreenshotConfig("WXGA+", 1440, 900, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("WSXGA+", 1680, 1050, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("HD", 1366, 768, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("HD+", 1600, 900, ScreenshotConfig.Format.PNG),            
            new ScreenshotConfig("Full HD", 1920, 1080, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("Quad HD", 2560, 1440, ScreenshotConfig.Format.PNG),
            new ScreenshotConfig("4K UHD", 3840, 2160, ScreenshotConfig.Format.PNG)
        };
    }
}