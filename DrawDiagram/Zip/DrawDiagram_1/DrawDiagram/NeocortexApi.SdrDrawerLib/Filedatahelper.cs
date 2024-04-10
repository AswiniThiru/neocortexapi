using DrawDiagram.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeocortexApi.SdrDrawerLib
{
    /// <summary>
    /// Helper class for managing file data, image paths, and an instance of SdValueModel.
    /// </summary>
    public static class Filedatahelper
    {
        /// <summary>
        /// Stores the file data as a string.
        /// </summary>
        public static string filedata;

        /// <summary>
        /// Stores the image path.
        /// </summary>
        public static string imagepath;

        /// <summary>
        /// Stores the current SdValueModel instance.
        /// </summary>
        public static SdValueModel Sdvalue = new SdValueModel();

        /// <summary>
        /// Retrieves the file data.
        /// </summary>
        /// <returns>The file data as a string.</returns>
        public static string getfiledata()
        {
            return filedata;
        }

        /// <summary>
        /// Retrieves the image path.
        /// </summary>
        /// <returns>The image path as a string.</returns>
        public static string getimagepath()
        {
            return imagepath;
        }

        /// <summary>
        /// Retrieves the current SdValueModel instance.
        /// </summary>
        /// <returns>The current SdValueModel instance.</returns>
        public static SdValueModel getcurrentSD()
        {
            return Sdvalue;
        }

        /// <summary>
        /// Sets the current SdValueModel instance.
        /// </summary>
        /// <param name="model">The SdValueModel instance to set.</param>
        public static void setcurrentSD(SdValueModel model)
        {
            Sdvalue = model;
        }

        /// <summary>
        /// Sets the file data.
        /// </summary>
        /// <param name="content">The file data to set.</param>
        public static void setfiledata(string content)
        {
            filedata = content;
        }

        /// <summary>
        /// Sets the image path.
        /// </summary>
        /// <param name="path">The image path to set.</param>
        public static void setimagepath(string path)
        {
            imagepath = path;
        }
    }

}
