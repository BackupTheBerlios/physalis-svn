#region Using directives

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Physalis.Specs.Framework;
using Physalis.Utils;

#endregion

namespace Bundle
{
    public class TheActivator : IBundleActivator
    {
        public TheActivator()
        {

        }

        public void Start(IBundleContext context)
        {
            TracesProvider.TracesOutput.OutputTrace("The bundle is starting");
            TracesProvider.TracesOutput.OutputTrace("Id=" + context.Bundle.Id);
            TracesProvider.TracesOutput.OutputTrace("State=" + context.Bundle.State);

            FileSystemInfo file = context.GetDataFile(" ");
            TracesProvider.TracesOutput.OutputTrace("File is: " + file.GetType().Name);
            TracesProvider.TracesOutput.OutputTrace("File name: " + file.FullName);
            if(!file.Exists)
            {
                DirectoryInfo dir = file as DirectoryInfo;
                dir.Create();
            }

            file = context.GetDataFile("bundle_file.txt");
            TracesProvider.TracesOutput.OutputTrace("File is: " + file.GetType().Name);
            TracesProvider.TracesOutput.OutputTrace("File name: " + file.FullName);

            if(!file.Exists)
            {
                FileInfo f = file as FileInfo;
                StreamWriter stream = f.CreateText();
                stream.Write("hello");
                stream.Flush();
                stream.Close();
            }
        }

        public void Stop(IBundleContext context)
        {
            TracesProvider.TracesOutput.OutputTrace("The bundle is stopping");
            TracesProvider.TracesOutput.OutputTrace("Id=" + context.Bundle.Id);
            TracesProvider.TracesOutput.OutputTrace("State=" + context.Bundle.State);

            DirectoryInfo folder = (DirectoryInfo) context.GetDataFile(" ");
            folder.Delete(true);
        }
    }
}
