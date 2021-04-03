using DevTool.Services.DatabaseConnect.Sqlite;
using Services.DatabaseConnect.Sqlite.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DevTool.Tools.LanguageCodeManager {
    public partial class LanguageCodes : Form {
        private List<Language> _datas;
        private int _columnIndex;
        private bool _asc;

        public LanguageCodes() {
            InitializeComponent();
            _datas = new List<Language>();
            _columnIndex = 0;
            _asc = true;
        }

        private void GetDatas(int offset, int limit) {
            var con = SqliteConnectionService.CreateConnection();
            string queryString = AttributeParse.EntityToList<Language>(offset, limit);
            try {
                //var data = SqliteConnectionService.Query(con, queryString);
                _datas.Clear();
                _datas = SqliteConnectionService.Query<Language>(con, queryString);
                //foreach (var item in data) {
                //    var value = new Language();
                //    value.Id = item.Value<long>("id");
                //    value.Name = item.Value<string>("name");
                //    value.Description = item.Value<string>("description");
                //    value.Version = item.Value<string>("version");
                //    value.CreatedOn = item.Value<DateTime>("created_on");
                //    value.IsActivated = item.Value<bool>("is_activated");
                //    _datas.Add(value);
                //}
                con.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Get data from database error");
                con.Close();
            }
            languageListData.DataSource = null;
            languageListData.DataSource = _datas;
            languageListData.AutoResizeColumns();
            this.Refresh();
        }

        private int CountDatas() {
            var con = SqliteConnectionService.CreateConnection();
            //string queryString = string.Format(DefineValue.QueryStringCount, DefineValue.TableName);
            string queryString = AttributeParse.EntityCount<Language>();
            int count = 0;
            try {
                var data = SqliteConnectionService.Query(con, queryString);
                count = data[0].Value<int>("count");
                con.Close();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Count data from database error");
                con.Close();
            }
            return count;
        }

        private bool ActionData(string query) {
            var con = SqliteConnectionService.CreateConnection();
            try {
                var data = SqliteConnectionService.Execute(con, query);
                con.Close();
                return data;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Count data from database error");
                con.Close();
            }
            return false;
        }

        private void LanguageCodes_Load(object sender, EventArgs e) {
            var count = SqliteConnectionService.Count<Language>(SqliteConnectionService.CreateConnection()); //CountDatas();
            if (count > 0) {
                GetDatas(0, 10);
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e) {
            var count = SqliteConnectionService.Count<Language>(SqliteConnectionService.CreateConnection());//var count = CountDatas();
            if (count > 0) {
                GetDatas(0, 10);
            }
        }

        private void btnPreviousPage_Click(object sender, EventArgs e) {

        }

        private void btnNextPage_Click(object sender, EventArgs e) {

        }

        private void btnCreate_Click(object sender, EventArgs e) {
            Language lan = new Language();
            lan.Name = languageName.Text;
            lan.Version = languageVersion.Text;
            lan.Description = languageDescription.Text;
            lan.IsActivated = chkIsActivated.Checked;
            lan.UpdatedOn = DateTime.Now;
            string query = "";
            if (string.IsNullOrEmpty(languageId.Text)) {
                lan.Id = _datas.Count + 1;
                lan.CreatedOn = DateTime.Now;
                query = AttributeParse.EntityToInsert(lan);
            } else {
                lan.CreatedOn = DateTime.Parse(createdOn.Text);
                lan.Id = long.Parse(languageId.Text);
                query = AttributeParse.EntityToUpdate(lan);
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
                updateOn.Text = row.Cells[4].Value.ToString();
                chkIsActivated.Checked = (bool)row.Cells[5].Value;
                languageDescription.Text = row.Cells[6].Value.ToString();
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
                        updateOn.Text = cell.Value.ToString();
                        break;
                    case 5:
                        chkIsActivated.Checked = (bool)cell.Value;
                        break;
                    case 6:
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
                        _datas = _datas.OrderBy(x => x.Version).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.Version).ToList();
                    break;
                case 3:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.CreatedOn).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.CreatedOn).ToList();
                    break;
                case 4:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.UpdatedOn).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.UpdatedOn).ToList();
                    break;
                case 5:
                    if (_asc)
                        _datas = _datas.OrderBy(x => x.IsActivated).ToList();
                    else
                        _datas = _datas.OrderByDescending(x => x.IsActivated).ToList();
                    break;
                case 6:
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
