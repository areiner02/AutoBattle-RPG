using System;
using System.Collections.Generic;

public static class MessageHelper
{
    private static List<string> messageList = new List<string>();

    public static void DrawTitle(string title)
    {
        string top = " ";
        string bottom = " ";
        for (int i = 0; i < title.Length + 8; i++)
        {
            top += "-";
            bottom += "-";
        }

        Console.WriteLine(top);
        Console.WriteLine($"|    {title}    |");
        Console.WriteLine(bottom + "\n");
    }

    public static void DrawTitle(string title, bool clear)
    {
        if (clear) Console.Clear();

        string top = " ";
        string bottom = " ";
        for (int i = 0; i < title.Length + 8; i++)
        {
            top += "-";
            bottom += "-";
        }

        Console.WriteLine(top);
        Console.WriteLine($"|    {title}    |");
        Console.WriteLine(bottom + "\n");
    }

    public static void InputlessDisplayMessage()
    {
        foreach (string message in messageList) Console.WriteLine(message);
        Console.Write(Environment.NewLine);

        messageList.Clear();
    }

    public static void InputlessDisplayMessage(string message)
    {
        Console.WriteLine(message);
        Console.Write(Environment.NewLine);
    }

    public static ConsoleKeyInfo DisplayMessage()
    {
        foreach (string message in messageList) Console.WriteLine(message);

        messageList.Clear();

        return Console.ReadKey();
    }

    public static ConsoleKeyInfo DisplayMessage(string message)
    {
        Console.WriteLine(message);
        Console.Write(Environment.NewLine);
        return Console.ReadKey();
    }

    public static ConsoleKeyInfo DrawInstruction(string message)
    {
        Console.Write(Environment.NewLine);
        Console.WriteLine(message);
        Console.Write(Environment.NewLine);

        return Console.ReadKey();
    }

    public static void AppendMessage(string message)
    {
        messageList.Add(message);
    }

    public static void AppendMessage(string[] messages)
    {
        foreach (string message in messages) messageList.Add(message);
    }
}