using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceStudio
{
    public class SequenceEventArgs : EventArgs
    {
        public SequenceEventArgs(string message, string source, string methodName)
        {
            Message = message; Source = source; MethodName = methodName;
        }

        public string Message { get; set; }
        public string Source { get; set; }
        public string MethodName { get; set; }
    }

    public class EventPublisher
    {
        public event EventHandler<SequenceEventArgs> SequenceEvent;
        public event EventHandler<SequenceEventArgs> NcbiFetchStarted;


        #region SequenceEvent Declarations
        public virtual void OnSequenceCreated(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }

        public virtual void OnSequenceError(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }

        #endregion



        #region NcbiEvent Declarations

        public virtual void OnNcbiSearchReturned(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }

        public virtual void OnNcbiSearchStarted(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }

        public virtual void OnNcbiSearchError(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }


        public virtual void OnNcbiFetchStarted(SequenceEventArgs e)
        {
            NcbiFetchStarted?.Invoke(this, e);
        }
        
        public virtual void OnNcbiFetchReturned(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }
       
        public virtual void OnNcbiFetchCancelled(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }
        

        public virtual void OnNcbiError(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }

        public virtual void OnNcbiDatabaseUpdated(SequenceEventArgs e)
        {
            SequenceEvent?.Invoke(this, e);
        }

        
        #endregion
    }

}
