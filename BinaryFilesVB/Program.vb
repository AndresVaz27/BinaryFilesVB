Imports System
Imports System.IO

Module Program
    Sub Main(args As String())
        Try

            Using fs As FileStream = New FileStream("data.bin", FileMode.OpenOrCreate, FileAccess.Write)
                Dim writer As BinaryWriter = New BinaryWriter(fs)
                writer.Write(12345)
                writer.Write(3.14159)
                writer.Write("Hello world")
            End Using

        Catch ex As IOException
            Console.WriteLine("Error: Could not create file. " & ex.Message)
            Return
        End Try

        Try

            Using fs As FileStream = New FileStream("data.bin", FileMode.Open, FileAccess.Read)
                Dim reader As BinaryReader = New BinaryReader(fs)
                Dim intValue As Integer = reader.ReadInt32()
                Dim doubleValue As Double = reader.ReadDouble()
                Dim stringValue As String = reader.ReadString()
                Console.WriteLine("Integer value: " & intValue)
                Console.WriteLine("Double value: " & doubleValue)
                Console.WriteLine("String value: " & stringValue)
            End Using

        Catch ex As IOException
            Console.WriteLine("Error: Could not open file. " & ex.Message)
        Catch ex As EndOfStreamException
            Console.WriteLine("Error: End of file reached. " & ex.Message)
        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try

        Console.ReadLine()
    End Sub
End Module
