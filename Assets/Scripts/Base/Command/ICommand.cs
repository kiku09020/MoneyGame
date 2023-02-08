using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand
{
    /// <summary>
    /// é¿çs
    /// </summary>
    void Execute();

    /// <summary>
    /// Excute()ÇÃãtÇÃÇ±Ç∆ÇçsÇ§
    /// </summary>
    void Undo();
}

namespace Example {
    class ExampleCommand : ICommand {
        int num;

        public void Execute()
        {
            num++;
        }

        public void Undo()
        {
            num--;
        }
    }
}