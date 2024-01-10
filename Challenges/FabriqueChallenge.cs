using CryptoClient.Challenges.Realisations;

namespace CryptoClient.Challenges
{
    public class FabriqueChallenge
    {
        public static IChallenge Creer(string code)
        {
            if (code == "COM1") { return new ChallengeCOM1(); }
            else if (code == "COM2") { return new ChallengeCOM2(); }
            else if (code == "SUB1") { return new ChallengeSUB1(); }
            else if (code == "SUB2") { return new ChallengeSUB2(); }
            else if (code == "SUB3") { return new ChallengeSUB3(); }
            else if (code == "SUB4") { return new ChallengeSUB4(); }
            else if (code == "SUB5") { return new ChallengeSUB5(); }
            else if (code == "SUB6") { return new ChallengeSUB6(); }
            else if (code == "VIG1") { return new ChallengeVIG1(); }
            else if (code == "VIG2") { return new ChallengeVIG2(); }
            else if (code == "VIG3") { return new ChallengeVIG3(); }
            else if (code == "VIG4") { return new ChallengeVIG4(); }
            else if (code == "XOR1") { return new ChallengeXOR1(); }
            else if (code == "XOR2") { return new ChallengeXOR2(); }
            else if (code == "XOR3") { return new ChallengeXOR3(); }
            return null;
        }
    }
}
