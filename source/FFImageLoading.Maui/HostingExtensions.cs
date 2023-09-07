﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FFImageLoading.Maui
{
	public static class HostingExtensions
	{
//		static IImageSourceServiceCollection UseFFImageLoading(this IImageSourceServiceCollection imageSourceServices, IServiceCollection services)
//		{

////#if IOS || MACCATALYST || ANDROID
//			//imageSourceServices.RemoveAll<FileImageSource>();
//			//imageSourceServices.RemoveAll<StreamImageSource>();
//			//imageSourceServices.RemoveAll<UriImageSource>();

//			//imageSourceServices.AddService<FileImageSource, Platform.FileImageSourceService>();
//			//imageSourceServices.AddService<StreamImageSource, Platform.StreamImageSourceService>();
//			//imageSourceServices.AddService<UriImageSource, Platform.UriImageSourceService>();
////#endif

//			return imageSourceServices;
//		}

		public static MauiAppBuilder UseFFImageLoading(this MauiAppBuilder mauiAppBuilder)
		{

			FFImageLoading.HostingExtensions.RegisterServices(mauiAppBuilder.Services);

			mauiAppBuilder.ConfigureMauiHandlers(c =>
			{
				#if IOS || MACCATALYST || ANDROID || TIZEN || WINDOWS
				c.AddHandler(typeof(FFImageLoading.Maui.CachedImage), typeof(FFImageLoading.Maui.Platform.CachedImageHandler));
				#endif
			});
			//.ConfigureImageSources(imageSourceServices =>
			//{
			//	imageSourceServices.UseFFImageLoading(mauiAppBuilder.Services);
			//});



			return mauiAppBuilder;
		}
	}
}
