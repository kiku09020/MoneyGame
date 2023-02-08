using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// コマンドを呼び出すクラス
/// </summary>
public class CommandInvoker : MonoBehaviour
{
    /* stocks */
    static Stack<ICommand> undoStack = new Stack<ICommand>();
    static Stack<ICommand> redoStack = new Stack<ICommand>();

    /// <summary>
    /// コマンドを実行する
    /// </summary>
    public static void ExecuteCommand(ICommand command)
    {
        command.Execute();              // コマンド実行
                                        
        undoStack.Push(command);        // コマンドをundoStackに追加
        redoStack.Clear();              // redoStackの要素を削除
    }

    /// <summary>
    /// 戻す
    /// </summary>
    public static void UndoCommand()
    {
        if (undoStack.Count > 0) {
            var activeCommand = undoStack.Pop();        // undoStackから取り出し
            redoStack.Push(activeCommand);              // 取り出したコマンドをredoStackに追加
                                                        
            activeCommand.Undo();                       // 戻す
        }
    }

    /// <summary>
    /// 進む
    /// </summary>
    public static void RedoCommand()
    {
        if (redoStack.Count > 0) {
            var activeCommand = redoStack.Pop();        // redoStackから取り出す
            undoStack.Push(activeCommand);              // 取り出したコマンドをundoStackに追加
                                                        
            activeCommand.Execute();                    // 実行
        }
    }
}
