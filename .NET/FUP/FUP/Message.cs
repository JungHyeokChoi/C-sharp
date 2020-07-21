namespace FUP
{
    public class CONSTANTS
    {
        public const uint REQ_FILE_SEND = 0x01;            // 파일 전송 요청
        public const uint REP_FILE_SEND = 0x02;            // 파일 전송 응답
        public const uint FILE_SEND_DATA = 0x03;           // 파일 데이터
        public const uint FILE_SEND_RES = 0x04;            // 파일 전송 결과
        public const uint CONNECT_STATE_CHECK = 0x05;      // 연결 상태 체크

        public const byte NOT_FRAGMENTED = 0x00;     // 메세지 미분활 전송
        public const byte FRAGMENTED = 0x01;         // 메세지 분활 전송

        public const byte NOT_LASTMSG = 0x00;        // 메세지 분활 마지막 X
        public const byte LASTMSG = 0x01;            // 메세지 분활 마지막 O

        public const byte ACCEPTED = 0x01;            // 파일 전송 승인
        public const byte DENIED = 0x00;              // 파일 전송 거절

        public const byte FAIL = 0x00;                // 파일 전송 실패
        public const byte SUCCESS = 0x01;             // 파일 전송 성공

        public const byte DISCONNECT = 0x00;          // 연결 끊김
        public const byte CONNECT = 0x01;             // 연결
    }

    public interface ISerializable
    {
        byte[] GetBytes();
        int GetSize();
    }

    public class Message : ISerializable
    {
        public Header Header { get; set; }
        public ISerializable Body { get; set; }

        public byte[] GetBytes()
        {
            byte[] bytes = new byte[GetSize()];

            Header.GetBytes().CopyTo(bytes, 0);
            Body.GetBytes().CopyTo(bytes, Header.GetSize());

            return bytes;
        }

        public int GetSize()
        {
            return Header.GetSize() + Body.GetSize();
        }
    }
}
