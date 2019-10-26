namespace System.Runtime.CompilerServices {
    internal class __BlockReflectionAttribute : Attribute { }
}

namespace Microsoft.Xml.Serialization.GeneratedAssembly {


    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationWriter1 : System.Xml.Serialization.XmlSerializationWriter {

        public void Write5_Settings(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"Settings", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace1 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write2_Settings(@"Settings", namespace1, ((global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings)o), true, false, namespace1, @"");
        }

        public void Write6_ArrayOfCycle(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"ArrayOfCycle", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace2 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            {
                global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle> a = (global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle>)((global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle>)o);
                if ((object)(a) == null) {
                    WriteNullTagLiteral(@"ArrayOfCycle", defaultNamespace);
                }
                else {
                    WriteStartElement(@"ArrayOfCycle", namespace2, null, false);
                    for (int ia = 0; ia < ((System.Collections.ICollection)a).Count; ia++) {
                        string namespace3 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
                        Write3_Cycle(@"Cycle", namespace3, ((global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle)a[ia]), true, false, namespace3, @"");
                    }
                    WriteEndElement();
                }
            }
        }

        public void Write7_CurrentState(object o, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs ?? @"";
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"CurrentState", defaultNamespace);
                return;
            }
            TopLevelElement();
            string namespace4 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            Write4_CurrentState(@"CurrentState", namespace4, ((global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState)o), true, false, namespace4, @"");
        }

        void Write4_CurrentState(string n, string ns, global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"CurrentState", defaultNamespace);
            string namespace5 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"LongBreakAfter", namespace5, System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@LongBreakAfter)));
            string namespace6 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"DailyTarget", namespace6, System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@DailyTarget)));
            string namespace7 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"IsDailyTargetAchived", namespace7, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@IsDailyTargetAchived)));
            WriteEndElement(o);
        }

        void Write3_Cycle(string n, string ns, global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Cycle", defaultNamespace);
            string namespace8 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"Id", namespace8, ((global::System.String)o.@Id));
            string namespace9 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementString(@"TaskId", namespace9, ((global::System.String)o.@TaskId));
            string namespace10 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"StartDate", namespace10, FromDateTime(((global::System.DateTime)o.@StartDate)));
            string namespace11 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"FinishDate", namespace11, FromDateTime(((global::System.DateTime)o.@FinishDate)));
            string namespace12 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"IsFinished", namespace12, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@IsFinished)));
            WriteEndElement(o);
        }

        void Write2_Settings(string n, string ns, global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings o, bool isNullable, bool needType, string parentRuntimeNs = null, string parentCompileTimeNs = null) {
            string defaultNamespace = parentRuntimeNs;
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"Settings", defaultNamespace);
            string namespace13 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"WorkDuration", namespace13, System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@WorkDuration)));
            string namespace14 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"ShorBreakDuration", namespace14, System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@ShorBreakDuration)));
            string namespace15 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"LongBreakDuration", namespace15, System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@LongBreakDuration)));
            string namespace16 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"DailyTarget", namespace16, System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@DailyTarget)));
            string namespace17 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"PomodoroToLongBreak", namespace17, System.Xml.XmlConvert.ToString((global::System.Int32)((global::System.Int32)o.@PomodoroToLongBreak)));
            string namespace18 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"IsMuteSound", namespace18, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@IsMuteSound)));
            string namespace19 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"IsSceenOn", namespace19, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@IsSceenOn)));
            string namespace20 = ( parentCompileTimeNs == @"" && parentRuntimeNs != null ) ? parentRuntimeNs : @"";
            WriteElementStringRaw(@"IsAutoContinue", namespace20, System.Xml.XmlConvert.ToString((global::System.Boolean)((global::System.Boolean)o.@IsAutoContinue)));
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializationReader1 : System.Xml.Serialization.XmlSerializationReader {

        public object Read5_Settings(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id1_Settings && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    o = Read2_Settings(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":Settings");
            }
            return (object)o;
        }

        public object Read6_ArrayOfCycle(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id3_ArrayOfCycle && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    if (!ReadNull()) {
                        if ((object)(o) == null) o = new global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle>();
                        global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle> a_0_0 = (global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle>)o;
                        if ((Reader.IsEmptyElement)) {
                            Reader.Skip();
                        }
                        else {
                            Reader.ReadStartElement();
                            Reader.MoveToContent();
                            int whileIterations0 = 0;
                            int readerCount0 = ReaderCount;
                            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                                    if (((object) Reader.LocalName == (object)id4_Cycle && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                                        if ((object)(a_0_0) == null) Reader.Skip(); else a_0_0.Add(Read3_Cycle(true, true, defaultNamespace));
                                    }
                                    else {
                                        UnknownNode(null, @":Cycle");
                                    }
                                }
                                else {
                                    UnknownNode(null, @":Cycle");
                                }
                                Reader.MoveToContent();
                                CheckReaderCount(ref whileIterations0, ref readerCount0);
                            }
                        ReadEndElement();
                        }
                    }
                    else {
                        if ((object)(o) == null) o = new global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle>();
                        global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle> a_0_0 = (global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle>)o;
                    }
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":ArrayOfCycle");
            }
            return (object)o;
        }

        public object Read7_CurrentState(string defaultNamespace = null) {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                if (((object) Reader.LocalName == (object)id5_CurrentState && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                    o = Read4_CurrentState(true, true, defaultNamespace);
                }
                else {
                    throw CreateUnknownNodeException();
                }
            }
            else {
                UnknownNode(null, defaultNamespace ?? @":CurrentState");
            }
            return (object)o;
        }

        global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState Read4_CurrentState(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id5_CurrentState && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState o;
            o = new global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState();
            bool[] paramsRead = new bool[3];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations1 = 0;
            int readerCount1 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id6_LongBreakAfter && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@LongBreakAfter = System.Xml.XmlConvert.ToInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id7_DailyTarget && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@DailyTarget = System.Xml.XmlConvert.ToInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id8_IsDailyTargetAchived && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IsDailyTargetAchived = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[2] = true;
                    }
                    else {
                        UnknownNode((object)o, @":LongBreakAfter, :DailyTarget, :IsDailyTargetAchived");
                    }
                }
                else {
                    UnknownNode((object)o, @":LongBreakAfter, :DailyTarget, :IsDailyTargetAchived");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations1, ref readerCount1);
            }
            ReadEndElement();
            return o;
        }

        global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle Read3_Cycle(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Cycle && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle o;
            o = new global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle();
            bool[] paramsRead = new bool[5];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations2 = 0;
            int readerCount2 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id9_Id && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@Id = Reader.ReadElementContentAsString();
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id10_TaskId && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@TaskId = Reader.ReadElementContentAsString();
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id11_StartDate && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@StartDate = ToDateTime(Reader.ReadElementContentAsString());
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id12_FinishDate && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@FinishDate = ToDateTime(Reader.ReadElementContentAsString());
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id13_IsFinished && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IsFinished = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[4] = true;
                    }
                    else {
                        UnknownNode((object)o, @":Id, :TaskId, :StartDate, :FinishDate, :IsFinished");
                    }
                }
                else {
                    UnknownNode((object)o, @":Id, :TaskId, :StartDate, :FinishDate, :IsFinished");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations2, ref readerCount2);
            }
            ReadEndElement();
            return o;
        }

        global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings Read2_Settings(bool isNullable, bool checkType, string defaultNamespace = null) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id1_Settings && string.Equals( ((System.Xml.XmlQualifiedName)xsiType).Namespace, defaultNamespace ?? id2_Item))) {
            }
            else
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            if (isNull) return null;
            global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings o;
            o = new global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings();
            bool[] paramsRead = new bool[8];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            int whileIterations3 = 0;
            int readerCount3 = ReaderCount;
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    if (!paramsRead[0] && ((object) Reader.LocalName == (object)id14_WorkDuration && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@WorkDuration = System.Xml.XmlConvert.ToInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[0] = true;
                    }
                    else if (!paramsRead[1] && ((object) Reader.LocalName == (object)id15_ShorBreakDuration && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@ShorBreakDuration = System.Xml.XmlConvert.ToInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[1] = true;
                    }
                    else if (!paramsRead[2] && ((object) Reader.LocalName == (object)id16_LongBreakDuration && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@LongBreakDuration = System.Xml.XmlConvert.ToInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[2] = true;
                    }
                    else if (!paramsRead[3] && ((object) Reader.LocalName == (object)id7_DailyTarget && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@DailyTarget = System.Xml.XmlConvert.ToInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[3] = true;
                    }
                    else if (!paramsRead[4] && ((object) Reader.LocalName == (object)id17_PomodoroToLongBreak && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@PomodoroToLongBreak = System.Xml.XmlConvert.ToInt32(Reader.ReadElementContentAsString());
                        }
                        paramsRead[4] = true;
                    }
                    else if (!paramsRead[5] && ((object) Reader.LocalName == (object)id18_IsMuteSound && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IsMuteSound = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[5] = true;
                    }
                    else if (!paramsRead[6] && ((object) Reader.LocalName == (object)id19_IsSceenOn && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IsSceenOn = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[6] = true;
                    }
                    else if (!paramsRead[7] && ((object) Reader.LocalName == (object)id20_IsAutoContinue && string.Equals(Reader.NamespaceURI, defaultNamespace ?? id2_Item))) {
                        {
                            o.@IsAutoContinue = System.Xml.XmlConvert.ToBoolean(Reader.ReadElementContentAsString());
                        }
                        paramsRead[7] = true;
                    }
                    else {
                        UnknownNode((object)o, @":WorkDuration, :ShorBreakDuration, :LongBreakDuration, :DailyTarget, :PomodoroToLongBreak, :IsMuteSound, :IsSceenOn, :IsAutoContinue");
                    }
                }
                else {
                    UnknownNode((object)o, @":WorkDuration, :ShorBreakDuration, :LongBreakDuration, :DailyTarget, :PomodoroToLongBreak, :IsMuteSound, :IsSceenOn, :IsAutoContinue");
                }
                Reader.MoveToContent();
                CheckReaderCount(ref whileIterations3, ref readerCount3);
            }
            ReadEndElement();
            return o;
        }

        protected override void InitCallbacks() {
        }

        string id2_Item;
        string id18_IsMuteSound;
        string id17_PomodoroToLongBreak;
        string id4_Cycle;
        string id3_ArrayOfCycle;
        string id16_LongBreakDuration;
        string id15_ShorBreakDuration;
        string id13_IsFinished;
        string id20_IsAutoContinue;
        string id8_IsDailyTargetAchived;
        string id19_IsSceenOn;
        string id1_Settings;
        string id12_FinishDate;
        string id14_WorkDuration;
        string id9_Id;
        string id10_TaskId;
        string id5_CurrentState;
        string id6_LongBreakAfter;
        string id7_DailyTarget;
        string id11_StartDate;

        protected override void InitIDs() {
            id2_Item = Reader.NameTable.Add(@"");
            id18_IsMuteSound = Reader.NameTable.Add(@"IsMuteSound");
            id17_PomodoroToLongBreak = Reader.NameTable.Add(@"PomodoroToLongBreak");
            id4_Cycle = Reader.NameTable.Add(@"Cycle");
            id3_ArrayOfCycle = Reader.NameTable.Add(@"ArrayOfCycle");
            id16_LongBreakDuration = Reader.NameTable.Add(@"LongBreakDuration");
            id15_ShorBreakDuration = Reader.NameTable.Add(@"ShorBreakDuration");
            id13_IsFinished = Reader.NameTable.Add(@"IsFinished");
            id20_IsAutoContinue = Reader.NameTable.Add(@"IsAutoContinue");
            id8_IsDailyTargetAchived = Reader.NameTable.Add(@"IsDailyTargetAchived");
            id19_IsSceenOn = Reader.NameTable.Add(@"IsSceenOn");
            id1_Settings = Reader.NameTable.Add(@"Settings");
            id12_FinishDate = Reader.NameTable.Add(@"FinishDate");
            id14_WorkDuration = Reader.NameTable.Add(@"WorkDuration");
            id9_Id = Reader.NameTable.Add(@"Id");
            id10_TaskId = Reader.NameTable.Add(@"TaskId");
            id5_CurrentState = Reader.NameTable.Add(@"CurrentState");
            id6_LongBreakAfter = Reader.NameTable.Add(@"LongBreakAfter");
            id7_DailyTarget = Reader.NameTable.Add(@"DailyTarget");
            id11_StartDate = Reader.NameTable.Add(@"StartDate");
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReader1();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriter1();
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class SettingsSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"Settings", this.DefaultNamespace ?? @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write5_Settings(objectToSerialize, this.DefaultNamespace, @"");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read5_Settings(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class ListOfCycleSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"ArrayOfCycle", this.DefaultNamespace ?? @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write6_ArrayOfCycle(objectToSerialize, this.DefaultNamespace, @"");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read6_ArrayOfCycle(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public sealed class CurrentStateSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"CurrentState", this.DefaultNamespace ?? @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write7_CurrentState(objectToSerialize, this.DefaultNamespace, @"");
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read7_CurrentState(this.DefaultNamespace);
        }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReader1(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriter1(); } }
        System.Collections.IDictionary readMethods = null;
        public override System.Collections.IDictionary ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, string>();
                    _tmp[@"Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings::"] = @"Read5_Settings";
                    _tmp[@"System.Collections.Generic.List`1[[Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle, Atrx.Mobile.Windows.Pomodoro.Repository, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]::"] = @"Read6_ArrayOfCycle";
                    _tmp[@"Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState::"] = @"Read7_CurrentState";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.IDictionary writeMethods = null;
        public override System.Collections.IDictionary WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, string>();
                    _tmp[@"Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings::"] = @"Write5_Settings";
                    _tmp[@"System.Collections.Generic.List`1[[Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle, Atrx.Mobile.Windows.Pomodoro.Repository, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]::"] = @"Write6_ArrayOfCycle";
                    _tmp[@"Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState::"] = @"Write7_CurrentState";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.IDictionary typedSerializers = null;
        public override System.Collections.IDictionary TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.IDictionary _tmp = new System.Collections.Generic.Dictionary<string, System.Xml.Serialization.XmlSerializer>();
                    _tmp.Add(@"System.Collections.Generic.List`1[[Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle, Atrx.Mobile.Windows.Pomodoro.Repository, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]]::", new ListOfCycleSerializer());
                    _tmp.Add(@"Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings::", new SettingsSerializer());
                    _tmp.Add(@"Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState::", new CurrentStateSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings)) return true;
            if (type == typeof(global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle>)) return true;
            if (type == typeof(global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState)) return true;
            if (type == typeof(global::System.Reflection.TypeInfo)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Settings)) return new SettingsSerializer();
            if (type == typeof(global::System.Collections.Generic.List<global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.Cycle>)) return new ListOfCycleSerializer();
            if (type == typeof(global::Atrx.Mobile.Windows.Pomodoro.Repository.Models.CurrentState)) return new CurrentStateSerializer();
            return null;
        }
        public static global::System.Xml.Serialization.XmlSerializerImplementation GetXmlSerializerContract() { return new XmlSerializerContract(); }
    }

    [System.Runtime.CompilerServices.__BlockReflection]
    public static class ActivatorHelper {
        public static object CreateInstance(System.Type type) {
            System.Reflection.TypeInfo ti = System.Reflection.IntrospectionExtensions.GetTypeInfo(type);
            foreach (System.Reflection.ConstructorInfo ci in ti.DeclaredConstructors) {
                if (!ci.IsStatic && ci.GetParameters().Length == 0) {
                    return ci.Invoke(null);
                }
            }
            return System.Activator.CreateInstance(type);
        }
    }
}
