using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessInsightRiskTechnologies;
using InsightRiskTechnologiesEntity;

namespace ConsoleTestingWCF
{
    public class Program
    {
        static void Main(string[] args)
        {
            MemberERT obj = new MemberERT();
            List<CommentsERT> lsobjComments = new List<CommentsERT>();
            try
            {
                lsobjComments = obj.ListCommentsERT(94, 156);
                //return lsobjComments;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                obj = null;
                lsobjComments = null;
            }
        }
    }
}
