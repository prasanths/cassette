﻿#region License
/*
Copyright 2011 Andrew Davey

This file is part of Cassette.

Cassette is free software: you can redistribute it and/or modify it under the 
terms of the GNU General Public License as published by the Free Software 
Foundation, either version 3 of the License, or (at your option) any later 
version.

Cassette is distributed in the hope that it will be useful, but WITHOUT ANY 
WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS 
FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.

You should have received a copy of the GNU General Public License along with 
Cassette. If not, see http://www.gnu.org/licenses/.
*/
#endregion

using Cassette.BundleProcessing;
using Cassette.Configuration;
using Moq;
using Xunit;

namespace Cassette.HtmlTemplates
{
    public class HtmlTemplateBundle_Tests
    {
        [Fact]
        public void ProcessCallsProcessor()
        {
            var bundle = new HtmlTemplateBundle("~");
            var processor = new Mock<IBundleProcessor<HtmlTemplateBundle>>();
            var settings = new CassetteSettings();
            bundle.Processor = processor.Object;

            bundle.Process(settings);

            processor.Verify(p => p.Process(bundle, settings));
        }

        [Fact]
        public void RenderCallsRenderer()
        {
            var bundle = new HtmlTemplateBundle("~");
            var renderer = new Mock<IBundleHtmlRenderer<HtmlTemplateBundle>>();
            bundle.Renderer = renderer.Object;

            bundle.Render();

            renderer.Verify(p => p.Render(bundle));
        }
    }
}
