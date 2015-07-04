using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Roslyn.Compilers;
using Roslyn.Compilers.CSharp;
using Roslyn.Scripting;
using Roslyn.Scripting.CSharp;

namespace EasimerDemoScene
{
    class Scripting
    {
    	//EasimerScript funkciók
    	public static void MessageBoxShow(string title, string text)
    	{
    		MessageBox.Show(text, title);
    	}
    	
    	//Hülyeségek
    	public static string LoadScript()
    	{
    		StreamReader streamReader = new StreamReader("./easimerscript/main.esc");
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			return text;
    	}
    	public static void RunScript(string script)
    	{
    		Session session = Session.Create();
			ScriptEngine engine = new ScriptEngine();
			engine.Execute(script, session);
    	}
    }
}
