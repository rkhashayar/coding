using System;
using System.Collections.Generic;
using System.Text;

namespace Chapter12
{
    public interface IBeatObservable
    {
        void NotifyBeatObservers();
        void NotifyBpmObservers();
        void RegisterObserver(IBeatObserver beatObserver);
        void RemoveObserver(IBeatObserver beatObserver);
        void RegisterObserver(IBPMObserver bPMObserver);
        void RemoveObserver(IBPMObserver bPMObserver);
    }
    public interface IBeatObserver
    {

    }
    public interface IBPMObserver
    {

    }
    public interface IBeatModel
    {
        void Initialize();
        void On();
        void Off();
        void SetBPM(int bpm);
        int GetBPM();        
    }

    public interface ISequencer
    {
        void Start();
        void Stop();
        void SetTempoInBpm(int bpm);
    }

    public class BeatModel : IBeatModel, IBeatObservable
    {
        private ISequencer _sequencer;
        private List<IBPMObserver> _bPMObservers = new List<IBPMObserver>();
        private List<IBeatObserver> _beatObservers = new List<IBeatObserver>();
        private int _bpm = 90;
        public int GetBPM()
        {
            return _bpm;
        }

        public void Initialize()
        {
            SetUpMIDI();
            BuildTrackAndStart();
        }

        public void Off()
        {
            SetBPM(0);
            _sequencer.Stop();
        }

        public void On()
        {
            _sequencer.Start();
            SetBPM(90);
        }

        public void RegisterObserver(IBeatObserver beatObserver)
        {
            _beatObservers.Add(beatObserver);
        }

        public void RegisterObserver(IBPMObserver bPMObserver)
        {
            _bPMObservers.Add(bPMObserver);
        }

        public void RemoveObserver(IBeatObserver beatObserver)
        {
            _beatObservers.Remove(beatObserver);
        }

        public void RemoveObserver(IBPMObserver bPMObserver)
        {
            _bPMObservers.Remove(bPMObserver);
        }

        public void SetBPM(int bpm)
        {
            _bpm = bpm;
            _sequencer.SetTempoInBpm(GetBPM());
            NotifyBpmObservers();
        }

        public void SetUpMIDI()
        {
            throw new NotImplementedException();
        }
        public void BuildTrackAndStart()
        {
            throw new NotImplementedException();
        }

        public void NotifyBeatObservers()
        {
            throw new NotImplementedException();
        }

        public void NotifyBpmObservers()
        {
            throw new NotImplementedException();
        }
        private void BeatEvent()
        {
            NotifyBeatObservers();
        }
    }
}
