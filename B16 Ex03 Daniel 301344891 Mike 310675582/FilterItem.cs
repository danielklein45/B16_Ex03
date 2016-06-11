using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Reflection;

using FacebookWrapper.ObjectModel;

namespace FacebookSmartView
{
    public class FilterItem : IXmlSerializable, IFilter
    {
        private IFilterStrategy m_FilterStrategy;

        private static readonly string sr_FilterStrategy = "Strategy";
        private static readonly string sr_FilterTextAttribute = "TextToFilter";

        public FilterItem() : this(null) { }
        
        public FilterItem(IFilterStrategy i_FilterStrategy)
        {
            m_FilterStrategy = i_FilterStrategy;
        }

        public override string ToString()
        {
            return m_FilterStrategy.ToString();
        }

        public bool IsMatch(Post i_Post)
        {
            bool isMatched = false;

            if (i_Post.Message != null)
            {
                isMatched = m_FilterStrategy.IsMatch(i_Post.Message);
            }

            return isMatched;
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader i_Reader)
        {
            string filterStrategy = i_Reader.GetAttribute(sr_FilterStrategy);
            string textToFilter = i_Reader.GetAttribute(sr_FilterTextAttribute);

            if (textToFilter != null)
            {
                m_FilterStrategy = (IFilterStrategy)Activator.CreateInstance(Assembly.GetExecutingAssembly().GetType(filterStrategy), textToFilter);
            }
        }

        public void WriteXml(XmlWriter i_Writer)
        {
            i_Writer.WriteAttributeString(sr_FilterStrategy, m_FilterStrategy.GetType().ToString());
            i_Writer.WriteAttributeString(sr_FilterTextAttribute, m_FilterStrategy.ToString());
        }
    }
}
