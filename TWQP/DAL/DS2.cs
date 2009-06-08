using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
	/// <summary>
	/// 与数据库结构对应的强类型数据集，含表，视图，表值函数的定义
	/// </summary>
	[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
	[Serializable()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.ComponentModel.ToolboxItem(true)]
	[System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
	[System.Xml.Serialization.XmlRootAttribute("DS2")]
	[System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
	public partial class DS2 : System.Data.DataSet {


		/// <summary>
		/// 根据主键比较两个 Row 是否相等。要求至少 r1 所在表必须有主键列定义。
		/// </summary>
		public static bool CompareRow(DataRow r1, DataRow r2)
		{
			DataTable t1 = r1.Table, t2 = r2.Table;
			DataColumn[] pk1 = t1.PrimaryKey;
			if (pk1 == null || pk1.Length == 0 || t2.Columns.Count < pk1.Length) return false;
			foreach (DataColumn c1 in pk1)
			{
				DataColumn c2 = t2.Columns[c1.ColumnName];
				if (c2 == null || c1.DataType != c2.DataType || r2.IsNull(c2) || r1[c1] != r2[c2]) return false;
			}
			return true;
		}

		/// <summary>
		/// 根据 r 的主键字段在 dt 表的 Rows 中查找 Row 并返回
		/// </summary>
		public static DataRow FindRow(DataTable dt, DataRow r)
		{
			if (dt == null || dt.Rows.Count == 0) return null;
			DataTable t = r.Table;
			DataColumn[] pk = t.PrimaryKey;
			if (pk == null || pk.Length == 0 || dt.Columns.Count < pk.Length) return null;
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				DataRow r2 = dt.Rows[i];
				if (CompareRow(r, r2)) return r2;
			}
			return null;
		}


		
		private System.Data.SchemaSerializationMode _schemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		public DS2() {
			this.BeginInit();
			this.InitClass();
			System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
			base.Tables.CollectionChanged += schemaChangedHandler;
			base.Relations.CollectionChanged += schemaChangedHandler;
			this.EndInit();
		}

		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		protected DS2(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : 
				base(info, context, false) {
			if ((this.IsBinarySerialized(info, context) == true)) {
				this.InitVars(false);
				System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler1 = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
				this.Tables.CollectionChanged += schemaChangedHandler1;
				this.Relations.CollectionChanged += schemaChangedHandler1;
				return;
			}
			string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
			if ((this.DetermineSchemaSerializationMode(info, context) == System.Data.SchemaSerializationMode.IncludeSchema)) {
				System.Data.DataSet ds = new System.Data.DataSet();
				ds.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));

				this.DataSetName = ds.DataSetName;
				this.Prefix = ds.Prefix;
				this.Namespace = ds.Namespace;
				this.Locale = ds.Locale;
				this.CaseSensitive = ds.CaseSensitive;
				this.EnforceConstraints = ds.EnforceConstraints;
				this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
				this.InitVars();
			}
			else {
				this.ReadXmlSchema(new System.Xml.XmlTextReader(new System.IO.StringReader(strSchema)));
			}
			this.GetSerializationData(info, context);
			System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
			base.Tables.CollectionChanged += schemaChangedHandler;
			this.Relations.CollectionChanged += schemaChangedHandler;
		}
		

		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.ComponentModel.BrowsableAttribute(true)]
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Visible)]
		public override System.Data.SchemaSerializationMode SchemaSerializationMode {
			get {
				return this._schemaSerializationMode;
			}
			set {
				this._schemaSerializationMode = value;
			}
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public new System.Data.DataTableCollection Tables {
			get {
				return base.Tables;
			}
		}
		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
		public new System.Data.DataRelationCollection Relations {
			get {
				return base.Relations;
			}
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		protected override void InitializeDerivedDataSet() {
			this.BeginInit();
			this.InitClass();
			this.EndInit();
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		public override System.Data.DataSet Clone() {
			DS2 cln = ((DS2)(base.Clone()));
			cln.InitVars();
			cln.SchemaSerializationMode = this.SchemaSerializationMode;
			return cln;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		protected override bool ShouldSerializeTables() {
			return false;
		}
		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		protected override bool ShouldSerializeRelations() {
			return false;
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		protected override void ReadXmlSerializable(System.Xml.XmlReader reader) {
			if ((this.DetermineSchemaSerializationMode(reader) == System.Data.SchemaSerializationMode.IncludeSchema)) {
				this.Reset();
				System.Data.DataSet ds = new System.Data.DataSet();
				ds.ReadXml(reader);
				this.DataSetName = ds.DataSetName;
				this.Prefix = ds.Prefix;
				this.Namespace = ds.Namespace;
				this.Locale = ds.Locale;
				this.CaseSensitive = ds.CaseSensitive;
				this.EnforceConstraints = ds.EnforceConstraints;
				this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
				this.InitVars();
			}
			else {
				this.ReadXml(reader);
				this.InitVars();
			}
		}
		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			this.WriteXmlSchema(new System.Xml.XmlTextWriter(stream, null));
			stream.Position = 0;
			return System.Xml.Schema.XmlSchema.Read(new System.Xml.XmlTextReader(stream), null);
		}

		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		internal void InitVars() {
			this.InitVars(true);
		}
		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		internal void InitVars(bool initTable) {
		}

		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		private void InitClass() {
			this.CaseSensitive = true;
			this.DataSetName = "DS2";
			this.Prefix = "";
			this.Namespace = "http://tempuri.org/DS2.xsd";
			this.EnforceConstraints = true;
			this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
		}

		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
			if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
				this.InitVars();
			}
		}
		
		[System.Diagnostics.DebuggerNonUserCodeAttribute()]
		public static System.Xml.Schema.XmlSchemaComplexType GetTypedDataSetSchema(System.Xml.Schema.XmlSchemaSet xs) {
			DS2 ds = new DS2();
			System.Xml.Schema.XmlSchemaComplexType type = new System.Xml.Schema.XmlSchemaComplexType();
			System.Xml.Schema.XmlSchemaSequence sequence = new System.Xml.Schema.XmlSchemaSequence();
			xs.Add(ds.GetSchemaSerializable());
			System.Xml.Schema.XmlSchemaAny any = new System.Xml.Schema.XmlSchemaAny();
			any.Namespace = ds.Namespace;
			sequence.Items.Add(any);
			type.Particle = sequence;
			return type;
		}
	


	}
}
