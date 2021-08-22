using Atata;

namespace Vote
{
    using _ = VotePage;
    public class VotePage : Page<_>
    {
        //[FindByName("#votebtn")]
        //[FindByXPath("@href='javascript:void(0);'")]
        [FindByClass("votebtn")]
        public Link<_> VoteBtn { get; private set; }
    }
}