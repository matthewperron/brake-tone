using System;
using System.Threading;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

class Program
{
    static void Main()
    {
        int[] frequencies = { 261, 277, 293, 311, 329, 349, 369, 392, 415, 440, 466, 493, 523 };
        int durationMs = 300;

        foreach (int freq in frequencies)
        {
            PlayTone(freq, durationMs);
            Thread.Sleep(100);
        }
    }

    static void PlayTone(int frequency, int durationMs)
    {
        using (var waveOut = new WaveOutEvent())
        {
            var sineWave = new SignalGenerator()
            {
                Frequency = frequency,
                Gain = 0.5,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromMilliseconds(durationMs));

            waveOut.Init(sineWave);
            waveOut.Play();
            Thread.Sleep(durationMs);
        }
    }
}
