using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrPortal.Models;
using System.IO;
using System.Web;

namespace HrPortal.Data
{
    public class PolicyRepository
    {

        private string _fileName = "DataFiles/policies.txt";

        public PolicyRepository()
        {
            // This code solves the problem between web and local file system.
            if (HttpContext.Current != null)
            {
                _fileName = HttpContext.Current.Server.MapPath("~/" + _fileName);
            }
        }

        //done
        public void AddPolicyToRepository(PolicyModel policy)
        {

            var policies = GetAllPolicies();
            //Maybe validaiton that it doesnt have the same name


            policies.Add(policy);

            WriteToFile(policies);
        }

        //done
        private List<PolicyModel> GetAllPolicies()
        {
            List<PolicyModel> policies = new List<PolicyModel>();

            using (var reader = File.OpenText(_fileName))
            {
                //read the header line
                reader.ReadLine();

                string inputLine;

                while ((inputLine = reader.ReadLine()) != null)
                {
                    string[] columns = inputLine.Split('|');
                    var policy = new PolicyModel()
                    {
                        Category = columns[0],
                        Title = columns[1],
                        Content = columns[2]

                    };

                    policies.Add(policy);
                }
            }

            return policies;
        }

        //done
        public List<CategoryModel> GetAllCategories()
        {
            var policies = GetAllPolicies();

            List<CategoryModel> categories = new List<CategoryModel>();
                
            var uniqueCategories = policies.Select(p => p.Category).Distinct().ToList();

            foreach (var cat in uniqueCategories)
            {
                CategoryModel category = new CategoryModel();
                category.CategoryName = cat;

                categories.Add(category);
            }

            return categories;
        }

        //done
        private void WriteToFile(List<PolicyModel> policies)
        {
            using (StreamWriter sw = new StreamWriter(_fileName))
            {
                foreach (var policy in policies)
                {
                    sw.WriteLine($"{policy.Category}|{policy.Title}|{policy.Content}");
                }

            }
        }

        //done
        public List<PolicyModel> GetPoliciesByCategory(string category)
        {
            var policiesInCat = new List<PolicyModel>();

            var allPolicies = GetAllPolicies();

            policiesInCat = allPolicies.Where(p => p.Category == category).ToList();
            

            return policiesInCat;


        }



    }
}
