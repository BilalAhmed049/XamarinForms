using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;

namespace MvvmAppDemo
{
		public interface ICognitiveClient
		{
			Task<AnalysisResult> GetImageDescription(Stream stream);
		}
}
