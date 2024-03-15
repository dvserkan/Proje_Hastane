using System;

namespace Proje_Hastane
{
    internal class RestRequest
    {
        private object pOST;

        public RestRequest(object pOST)
        {
            this.pOST = pOST;
        }

        internal void AddHeader(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        internal void AddParameter(string v, string body, object requestBody)
        {
            throw new NotImplementedException();
        }
    }
}