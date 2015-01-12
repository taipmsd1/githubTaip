using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VDS.RDF;
using VDS.RDF.Parsing;
using VDS.RDF.Query;
namespace Database
{
    public class RdfManager
    {
        private string _ontologypath;
        private Graph _graph;

        public RdfManager(String path)
        {
            _ontologypath = path;
            _graph = new Graph();
            FileLoader.Load(_graph, path);
        }
        private string QueryPart()
        {


            string prefixString = "";
            foreach (string abbreviation in _graph.NamespaceMap.Prefixes)
            {
                prefixString += "PREFIX " + abbreviation + ": <" + _graph.NamespaceMap.GetNamespaceUri(abbreviation) + ">\n";
            }
            prefixString += "PREFIX md: <http://www.semanticweb.org/andreea/ontologies/2015/Mediu#>" + "\n";
            return prefixString;

        }

        private Object Query(string myquery)
        {
            Object result;
            TripleStore tstore = new TripleStore();
            SparqlQueryParser parser = new SparqlQueryParser();
            string command = myquery;

            string query = QueryPart() + command;
            SparqlParameterizedString param = new SparqlParameterizedString(query);
            result = _graph.ExecuteQuery(param);
            return result;
        }

        public List<String> GetProblemeDeMediu()
        {
            List<String> problemeDeMediu = GetSubClassOf("ProblemeDeMediu");
            return problemeDeMediu;
        }

        public List<string> GetSectoareSiActivitati()
        {
            List<String> problemeDeMediu = GetSubClassOf("SectoareSiActivitati");
            return problemeDeMediu;
        }

        public List<string> GetSubClassOf(string className)
        {
            List<String> list = new List<string>();
            string query = "SELECT ?subject WHERE { ?subject rdfs:subClassOf md:" + className + " }ORDER BY ?subject";
            var result = Query(query);
            if (result is SparqlResultSet)
            {
                SparqlResultSet rset = (SparqlResultSet)result;
                if (!rset.IsEmpty)
                {
                    foreach (SparqlResult r in rset)
                    {
                        string text = r.ToString().Substring(r.ToString().IndexOf("#") + 1);
                        list.Add(text);
                    }
                }
            }
            return list;
        }
    }
}
