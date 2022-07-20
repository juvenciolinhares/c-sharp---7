using System;

namespace ExcResolvidoConjuntos.Entities
{
    internal class LogRecord
    {
        public string  UserName { get; set; }
        public DateTime Instant { get; set; }

        //verificação de elementos: GetHashCode, em seguidaEquals
        public override int GetHashCode()
        {
            //hascode apenas do username
            return UserName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if(!(obj is LogRecord))
            {
                return false;
            }
            //downcasting:
            LogRecord other = obj as LogRecord;
            return UserName.Equals(other.UserName);
        }
    }
}
