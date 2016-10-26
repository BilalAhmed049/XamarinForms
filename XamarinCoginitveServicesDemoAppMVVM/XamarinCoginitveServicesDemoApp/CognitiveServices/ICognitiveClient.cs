using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Vision.Contract;

namespace XamarinCoginitveServicesDemoApp
{
	public interface ICognitiveClient
	{
		Task<AnalysisResult> GetImageDescription(Stream stream);
	}
}
