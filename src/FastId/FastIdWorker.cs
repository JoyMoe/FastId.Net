using System;

namespace FastId
{
    public class FastIdWorker
    {
        private const ulong DefaultEpoch = 1527811200000;

        private readonly int _machineBits;
        private readonly int _sequenceBits;

        private readonly ulong _timeMask;
        private readonly ulong _machineMask;
        private readonly ulong _sequenceMask;

        private readonly ulong _epoch;
        private readonly ulong _machineId;

        private ulong _lastTimestamp;
        private ulong _sequence;

        public FastIdWorker(ulong machineId) : this(machineId, 40, 16, 7)
        {
        }

        public FastIdWorker(ulong machineId,
                            int   timeBits,
                            int   machineBits,
                            int   sequenceBits) : this(machineId, timeBits, machineBits, sequenceBits, DefaultEpoch)
        {
        }

        public FastIdWorker(ulong machineId,
                            int   timeBits,
                            int   machineBits,
                            int   sequenceBits,
                            ulong epoch)
        {
            _machineId = machineId;

            _machineBits  = machineBits;
            _sequenceBits = sequenceBits;

            _timeMask     = ~(ulong.MaxValue << timeBits);
            _machineMask  = ~(ulong.MaxValue << machineBits);
            _sequenceMask = ~(ulong.MaxValue << sequenceBits);

            _epoch = epoch;
        }

        private ulong GetCurrentTimestamp()
        {
            return (ulong) DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - _epoch;
        }

        public long NextId()
        {
            while (true)
            {
                var ts = GetCurrentTimestamp();
                if (ts > _lastTimestamp)
                {
                    _lastTimestamp = ts;
                    _sequence      = 0;
                }
                else if (_sequence >= _sequenceMask)
                {
                    continue;
                }
                else
                {
                    _sequence++;
                }

                var id = ((ts & _timeMask) << (_machineBits + _sequenceBits))
                       | ((_sequence & _sequenceMask) << _machineBits)
                       | (_machineId & _machineMask);

                return (long) id;
            }
        }
    }
}
