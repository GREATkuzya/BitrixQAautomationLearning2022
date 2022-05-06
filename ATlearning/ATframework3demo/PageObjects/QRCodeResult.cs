using QRCodeDecoderLibrary;

namespace atFrameWork2.PageObjects
{
    // QR Code result 
    public class QRCodeResult
    {
        // QR Code Data array
        public byte[] DataArray;

        // ECI Assignment Value
        public int ECIAssignValue;

        // the next members are for information only
        // QR Code matrix version
        public int QRCodeVersion;

        // QR Code matrix dimension in bits
        public int QRCodeDimension;

        // QR Code error correction code (L, M, Q, H)
        public ErrorCorrection ErrorCorrection;
    }
}