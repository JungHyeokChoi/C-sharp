using System;
using static System.Console;

namespace FUP
{
    //파일 전송 요청 메세지(0x01)
    public class BodyRequest : ISerializable
    {
        public long FILESIZE;
        public int FOLDERSIZE;
        public byte[] FILENAME;
        public byte[] FOLDERNAME;

        public BodyRequest() { }

        public BodyRequest(byte[] bytes)
        { 
            FILESIZE = BitConverter.ToInt64(bytes,0);
            FOLDERSIZE = BitConverter.ToInt32(bytes, sizeof(long));

            FILENAME = new byte[bytes.Length - (FOLDERSIZE + sizeof(long) + sizeof(int))];
            Array.Copy(bytes, sizeof(long) + sizeof(int) , FILENAME, 0, FILENAME.Length);

            FOLDERNAME = new byte[bytes.Length - (sizeof(long) + sizeof(int) + FILENAME.Length)];
            Array.Copy(bytes, (sizeof(long) + sizeof(int) + FILENAME.Length), FOLDERNAME, 0, FOLDERNAME.Length);
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];

            byte[] temp = BitConverter.GetBytes(FILESIZE);
            Array.Copy(temp, 0, bytes, 0, temp.Length);

            temp = BitConverter.GetBytes(FOLDERSIZE);
            Array.Copy(temp, 0, bytes, sizeof(long), temp.Length);

            Array.Copy(FILENAME, 0, bytes, sizeof(long) + sizeof(int), FILENAME.Length);

            Array.Copy(FOLDERNAME, 0, bytes, sizeof(long) + sizeof(int) + FILENAME.Length, FOLDERNAME.Length);
            
            return bytes;
        }

        public int GetSize()
        {
            return sizeof(long) + sizeof(int) + FILENAME.Length + FOLDERNAME.Length;
        }
    }

    //파일 전송 요청 응답(0x02)
    public class BodyResponse : ISerializable
    {
        public uint MSGID;
        public byte RESPONSE;

        public BodyResponse() { }
        public BodyResponse(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            RESPONSE = bytes[4];

            MessageUtil.ByteCheck(bytes);
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = RESPONSE;

            return bytes;

        }

        public int GetSize()
        {
            return sizeof(uint) + sizeof(byte);
        }
    }

    //파일 전송(0x03)
    public class BodyData : ISerializable
    {
        public byte[] DATA;

        public BodyData(byte[] bytes)
        {
            DATA = new byte[bytes.Length];
            bytes.CopyTo(DATA, 0);
        }

        public byte[] GetBytes()
        {
            return DATA;
        }

        public int GetSize()
        {
            return DATA.Length;
        }
    }

    //파일 전송 결과(0x04)
    public class BodyResult : ISerializable
    {
        public uint MSGID;
        public byte RESULT;

        public BodyResult() { }
        public BodyResult(byte[] bytes)
        {
            MSGID = BitConverter.ToUInt32(bytes, 0);
            RESULT = bytes[4];
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            byte[] temp = BitConverter.GetBytes(MSGID);
            Array.Copy(temp, 0, bytes, 0, temp.Length);
            bytes[temp.Length] = RESULT;

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(uint) + sizeof(byte);
        }
    }

    //연결 상태 체크(0x05)
    public class BodyCheck : ISerializable
    {
        public byte STATE;

        public BodyCheck() { }
        public BodyCheck(byte[] bytes)
        {
            STATE = bytes[0];
        }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];
            bytes[0] = STATE;

            return bytes;
        }

        public int GetSize()
        {
            return sizeof(byte);
        }
    }
}    

