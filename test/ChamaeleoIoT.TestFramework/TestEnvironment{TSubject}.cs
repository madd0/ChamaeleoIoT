using System;

namespace ChamaeleoIoT.Tests
{
    public abstract class TestEnvironment<TSubject>
    {
        private TSubject _subject;

        public TSubject Subject
        {
            get
            {
                if (_subject == null)
                {
                    _subject = this.CreateSubjectInstance();
                }

                return _subject;
            }
        }

        public void SetupEnvironment()
        {
            this.OnSetupEnvironment();
        }

        protected virtual TSubject CreateSubjectInstance()
        {
            return Activator.CreateInstance<TSubject>();
        }

        protected abstract void OnSetupEnvironment();
    }
}
