using System;
using System.IO;
using static System.Console;

namespace FUP
{
    public class MessageUtil
    {
        public static void Send(Stream writer, Message msg)
        {
            writer.Write(msg.GetBytes(), 0, msg.GetSize());
        }

        public static Message Receive(Stream reader)
        {
            int totalRecv = 0;
            int sizeToRead = 16;
            byte[] hBuffer = new byte[sizeToRead];

            while (sizeToRead > 0)
            {
                byte[] buffer = new byte[sizeToRead];
                int recv = reader.Read(buffer, 0, sizeToRead);
                if (recv == 0)
                    return null;

                buffer.CopyTo(hBuffer, totalRecv);
                totalRecv += recv;
                sizeToRead -= recv;
            }

            Header header = new Header(hBuffer);

            totalRecv = 0;
            byte[] bBuffer = new byte[header.BODYLEN];
            sizeToRead = (int)header.BODYLEN;

            while (sizeToRead > 0)
            {
                byte[] buffer = new byte[sizeToRead];
                int recv = reader.Read(buffer, 0, sizeToRead);
                if (recv == 0)
                    return null;

                buffer.CopyTo(bBuffer, totalRecv);
                totalRecv += recv;
                sizeToRead -= recv;
            }

            ISerializable body = null;
            switch (header.MSGTYPE)
            {
                case CONSTANTS.REQ_FILE_SEND:
                    body = new BodyRequest(bBuffer);
                    break;
                case CONSTANTS.REP_FILE_SEND:
                    body = new BodyResponse(bBuffer);
                    break;
                case CONSTANTS.FILE_SEND_DATA:
                    body = new BodyData(bBuffer);
                    break;
                case CONSTANTS.FILE_SEND_RES:
                    body = new BodyResult(bBuffer);
                    break;
                case CONSTANTS.CONNECT_STATE_CHECK:
                    body = new BodyCheck(bBuffer);
                    break;
                default:
                    throw new Exception(String.Format($"Unknown MSGTYPE : {header.MSGTYPE}"));
            }

            return new Message() { Header = header, Body = body };
        }

        public static string MsgCheck_Winform(Message msg)
        {
            string str;

            str = "<Header>\n";
            str += $"MSGID : {msg.Header.MSGID}\n";
            str += $"MSGTYPE : {msg.Header.MSGTYPE}\n";
            str += $"BODYLEN : {msg.Header.BODYLEN}\n";
            str += $"FRAGMENTED : {msg.Header.FRAGMENTED}\n";
            str += $"LASTMSG : {msg.Header.LASTMSG}\n";
            str += $"SEQ : {msg.Header.SEQ}\n";


            str += "<Body>\n";
            switch (msg.Header.MSGTYPE)
            {
                case CONSTANTS.REQ_FILE_SEND:
                    BodyRequest reqBody = (BodyRequest)msg.Body;
                    str += $"FileSize : {reqBody.FILESIZE}\n";
                    str += $"FolderSize : {reqBody.FOLDERSIZE}\n";
                    str += $"FileName : {System.Text.Encoding.Default.GetString(reqBody.FILENAME)}\n";
                    str += $"SaveFolderNameLenght : {System.Text.Encoding.Default.GetString(reqBody.FOLDERNAME)}\n";
                    break;
                case CONSTANTS.REP_FILE_SEND:
                    BodyResponse resBody = (BodyResponse)msg.Body;
                    str += $"MSGID : {resBody.MSGID}\n";
                    str += $"Respone : {resBody.RESPONSE}\n";
                    break;
                case CONSTANTS.FILE_SEND_DATA:
                    break;
                case CONSTANTS.FILE_SEND_RES:
                    BodyResult resultBody = (BodyResult)msg.Body;
                    str += $"MSGID : {resultBody.MSGID}\n";
                    str += $"Result : {resultBody.RESULT}\n";
                    break;
                case CONSTANTS.CONNECT_STATE_CHECK:
                    BodyCheck checkBody = (BodyCheck)msg.Body;
                    str += $"State : {checkBody.STATE}\n";
                    break;
                default:
                    throw new Exception(String.Format($"Unknown MSGTYPE : {msg.Header.MSGTYPE}"));
            }

            return str;
        }
        public static void MsgCheck_Console(Message msg)
        {
            WriteLine("<Header>");
            WriteLine($"MSGID : {msg.Header.MSGID}");
            WriteLine($"MSGTYPE : {msg.Header.MSGTYPE}");
            WriteLine($"BODYLEN : {msg.Header.BODYLEN}");
            WriteLine($"FRAGMENTED : {msg.Header.FRAGMENTED}");
            WriteLine($"LASTMSG : {msg.Header.LASTMSG}");
            WriteLine($"SEQ : {msg.Header.SEQ}");
            WriteLine();


            WriteLine("<Body>");
            switch (msg.Header.MSGTYPE)
            {
                case CONSTANTS.REQ_FILE_SEND:
                    BodyRequest reqBody = (BodyRequest)msg.Body;
                    WriteLine($"FileSize : {reqBody.FILESIZE}");
                    WriteLine($"FolderSize : {reqBody.FOLDERSIZE}");
                    WriteLine($"FileName : {System.Text.Encoding.Default.GetString(reqBody.FILENAME)}");
                    WriteLine($"SaveFolderNameLenght : {System.Text.Encoding.Default.GetString(reqBody.FOLDERNAME)}");
                    break;
                case CONSTANTS.REP_FILE_SEND:
                    BodyResponse resBody = (BodyResponse)msg.Body;
                    WriteLine($"MSGID : {resBody.MSGID}");
                    WriteLine($"Respone : {resBody.RESPONSE}");
                    break;
                case CONSTANTS.FILE_SEND_DATA:
                    break;
                case CONSTANTS.FILE_SEND_RES:
                    BodyResult resultBody = (BodyResult)msg.Body;
                    WriteLine($"MSGID : {resultBody.MSGID}");
                    WriteLine($"Result : {resultBody.RESULT}");
                    break;
                case CONSTANTS.CONNECT_STATE_CHECK:
                    BodyCheck checkBody = (BodyCheck)msg.Body;
                    WriteLine($"State : {checkBody.STATE}");
                    break;
                default:
                    throw new Exception(String.Format($"Unknown MSGTYPE : {msg.Header.MSGTYPE}"));
            }
            WriteLine();
        }
        public static void ByteCheck(byte[] bytes)
        {
            WriteLine("Byte Constain");
            WriteLine(BitConverter.ToString(bytes));
            WriteLine();
        }
    }
}
