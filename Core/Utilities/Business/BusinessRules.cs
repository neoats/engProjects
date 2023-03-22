using Core.Utilities.Results;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            //logic check rules in pm
            //go through all the rules, return if anyone does not follow the rules
            foreach (var logic in logics)
            {
                if (!logic.Success)
                    return logic;
            }

            return null;

            #region errorResultway 
            /*  var errorResults = new List<IResult>();
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    errorResults.Add(logic);
                }
            }

            return errorResults;
            }*/


            #endregion

        }
    }
}
