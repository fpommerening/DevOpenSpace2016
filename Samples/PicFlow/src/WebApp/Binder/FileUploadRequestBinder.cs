﻿using System;
using System.Collections.Generic;
using System.Linq;
using FP.DevSpace2016.PicFlow.WebApp.Models;
using Nancy;
using Nancy.ModelBinding;

namespace FP.DevSpace2016.PicFlow.WebApp.Binder
{
    public class FileUploadRequestBinder : IModelBinder
    {
        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration,
            params string[] blackList)
        {
            var imageRequest = (instance as ImageRequest) ?? new ImageRequest();

            var form = context.Request.Form;
            
            imageRequest.File = GetFileByKey(context, "file");
            imageRequest.ContentSize = GetContentSize(context);

            return imageRequest;
        }

        public bool CanBind(Type modelType)
        {
            return modelType == typeof(ImageRequest);
        }

        private HttpFile GetFileByKey(NancyContext context, string key)
        {
            IEnumerable<HttpFile> files = context.Request.Files;
            return files?.FirstOrDefault(x => x.Key == key);
        }

        private long GetContentSize(NancyContext context)
        {
            return context.Request.Headers.ContentLength;
        }
    }
}