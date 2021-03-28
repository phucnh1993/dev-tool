using DevTool.Services.DatabaseConnect.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DevTool.Tools.LanguageCodeManager {
    public partial class LanguageCodes : Form {
        private List<LanguageCode> _datas;
        private int _columnIndex;
        private bool _asc;
        public LanguageCodes() {
            InitializeComponent();
            _datas = new List<LanguageCode>();
            _columnIndex = 0;
            _asc = true;
        }

        private void GetDatas(uint offset, uint limit) {
            var con = SqliteConnectionController.CreateConnection(DefineValue.DatabaseName);
            string queryString = string.Format(DefineValue.QueryStringList, DefineValue.TableName, limit, offset);
            try {
                var data = SqliteConnectionController.Query(con, queryString);
                _datas.Clear();
                foreach (var item in data) {
                    var value = new LanguageCode();
                    value.Id = item.Value<long>("id");
                    value.Name = item.Value<string>("name");
                    value.Description = item.Value<string>("description");
                    value.VersionNow = item.Value<string>("version");
                    value.CreatedOn = item.Value<DateTime>("created_on");
                    value.IsActivated = item.Value<bool>("is_activated");
                    _datas.Add(value);
                }
                con.Close();
            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Get data from database error");
                con.Close();
            }
            languageListData.DataSource = null;
            languageListData.DataSource = _datas;
            languageListData.AutoResizeColumns();
            this.Refresh();
        }

        private int CountDatas() {
            var con = SqliteConnectionController.CreateConnection(DefineValue.DatabaseName);
            string queryString = string.Format(DefineValue.QueryStringCount, DefineValue.TableName);
            int count = 0;
            try {
                var data = SqliteConnectionController.Query(con, queryString);
                count = data[0].Value<int>("count");
                con.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Count data from database error");
                con.Close();
            }
            return count;
        }

        private bool ActionData(string query) {
            var con = SqliteConnectionController.CreateConnection(DefineValue.DatabaseName);
            try {
                var data = SqliteConnectionController.Execute(con, query);
                con.Close();
                return data;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Count data from database error");
                con.Close();
            }
            return false;
        }

        private void LanguageCodes_Load(object sender, EventArgs e) {
            var chk = SqliteSerivce.CheckTableExist(DefineValue.DatabaseName, DefineValue.TableName);
            if (!chk) {
                string rowInfo = "id INTEGER PRIMARY KEY, " +
                    "name TEXT(100) NOT NULL, " +
                    "description TEXT(500) NULL, " +
                    "version TEXT(20) NULL, " +
                    "created_on TEXT(30) NOT NULL, " +
                    "is_activated INTEGER";
                var cre = SqliteSerivce.CreateTable(DefineValue.DatabaseName, DefineValue.TableName, rowInfo);
            }
            var count = CountDatas();
            if (count > 0) {
                GetDatas(0, 10);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e) {
            var count = CountDatas();
            if (count > 0) {
                GetDatas(0, 10);
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e) {

        }

        private void btnNextPage_Click(object sender, EventArgs e) {

        }

        private void btnCreate_Click(object sender, EventArgs e) {
            LanguageCode lc = new LanguageCode();
            lc.Name = languageName.Text;
            lc.VersionNow = languageVersion.Text;
            lc.Description = languageDescription.Text;
            lc.IsActivated = chkIsActivated.Checked;
            string query = "";
            if (string.IsNullOrEmpty(languageId.Text)) {
                lc.CreatedOn = DateTime.Now;
                query = lc.CreateData();
            } else {
                lc.Id = long.Parse(languageId.Text);
                query = lc.UpdateData();
            }
            var chk = ActionData(query);
            if (!chk) {
                MessageBox.Show("Create or Update data error");
            }
            var count = CountDatas();
            if (count > 0) {
                GetDatas(0, 10);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {

        }

        private void languageId_KeyPress(object sender, KeyPressEventArgs e) {
            if (!Regex.IsMatch(languageId.Text, @"[\d]")) {
                MessageBox.Show("You only input number value","Input error");
            }
        }

        private void languageListData_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (languageListData.SelectedRows.Count > 0) {
                DataGridViewRow row = languageListData.SelectedRows[0];
                languageId.Text = row.Cells[0].Value.ToString();
                languageName.Text = row.Cells[1].Value.ToString();
                languageVersion.Text = row.Cells[2].Value.ToString();
                createdOn.Text = row.Cells[3].Value.ToString();
                chkIsActivated.Checked = (bool)row.Cells[4].Value;
                languageDescription.Text = row.Cells[5].Value.ToString();
                this.Refresh();
            }
            if (languageListData.SelectedCells.Count > 0) {
                var cell = languageListData.SelectedCells[0];
                switch (cell.ColumnIndex) {
                    case 0:
                        languageId.Text = cell.Value.ToString();
                        break;
                    case 1:
                        languageName.Text = cell.Value.ToString();
                        break;
                    case 2:
                        languageVersion.Text = cell.Value.ToString();
                        break;
                    case 3:
                        createdOn.Text = cell.Value.ToString();
                        break;
                    case 4:
                        chkIsActivated.Checked = (bool)cell.Value;
                        break;
                    case 5:
                        languageDescription.Text = cell.Value.ToString();
                        break;
                    default:
                        break;
                }
            }
        }

        private void languageListData_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            _asc = !((_columnIndex == e.ColumnIndex) && _asc);
            _columnIndex = e.ColumnIndex;
            switch (_columnIndex) {
                case 0:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.Id).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.Id).ToList();
                    break;
                case 1:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.Name).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.Name).ToList();
                    break;
                case 2:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.VersionNow).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.VersionNow).ToList();
                    break;
                case 3:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.CreatedOn).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.CreatedOn).ToList();
                    break;
                case 4:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.IsActivated).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.IsActivated).ToList();
                    break;
                case 5:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.Description).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.Description).ToList();
                    break;
                default:
                    break;
            }
            languageListData.DataSource = null;
            languageListData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            languageListData.DataSource = _datas;
        }
    }
}
