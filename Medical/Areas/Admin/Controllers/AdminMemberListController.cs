using Medical.Models;
using Medical.ViewModel;
using Medical.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medical.Areas.Admin.Controllers
{[Area(areaName: "Admin")]
    public class AdminMemberListController : Controller
    {
        private readonly MedicalContext _context;

        public AdminMemberListController(MedicalContext context)  //注入
        {
            _context = context;
        }
        //======================================================================
        public IActionResult AdminMemberList(CKeyWordViewModel keyVModel,int? Role)   //管理員帳號登入=>會員清單管理
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USE))  
            {
                if (string.IsNullOrEmpty(keyVModel.txtKeyword))    //沒關鍵字時
                {
                    if (Role!=null)   //使用下拉選單時
                    {
                        CMemberViewModel memVModel = new CMemberViewModel();
                   
                        memVModel.mem = _context.Members.Where(n => n.Role == Role).ToList();  //清單篩選顯示!!
                        memVModel.roleTypes = _context.RoleTypes.ToList();  //下拉選單顯示
                        return View(memVModel);
                    }
                    else
                    {
                        CMemberViewModel memVModel = new CMemberViewModel()
                        {
                            mem = _context.Members.ToList(),
                            roleTypes = _context.RoleTypes.ToList(),
                            MemGender = _context.Genders.ToList(),
                            MemCity = _context.Cities.ToList()
                    };  
                        return View(memVModel);
                    }
                 
                }
                else  //有關鍵字時
                {
                    CMemberViewModel VModel = new CMemberViewModel()
                    {
                        mem = _context.Members.Where(t => t.MemberName.Contains(keyVModel.txtKeyword) ||
                          t.Email.Contains(keyVModel.txtKeyword) || t.Phone.Contains(keyVModel.txtKeyword)).ToList(),
                                roleTypes = _context.RoleTypes.ToList()
                    };
                    return View(VModel);
                }

            }
            else   //沒登入或登入失效時
                return RedirectToAction("Index", "Home");
        }



        public IActionResult AdminCreate()
        {
            CMemberViewModel memVModel = new CMemberViewModel()
            {
                mem = _context.Members.ToList(),
                roleTypes = _context.RoleTypes.ToList(),
                MemCity = _context.Cities.ToList(),
                MemGender = _context.Genders.ToList()
            };
            return View(memVModel);
        }
        [HttpPost]
        public IActionResult AdminCreate(CMemberViewModel vModel)
        {
            if (vModel != null)
            {
                _context.Members.Add(vModel.member);
                _context.SaveChanges();
            }
            return RedirectToAction("AdminMemberList", "AdminMemberList");
        }

        public IActionResult Delete(int? id)
        {
            MedicalContext db = new MedicalContext();
            Member mem = db.Members.FirstOrDefault(c => c.MemberId == id);
            if (mem != null)
            {
                db.Members.Remove(mem);
                db.SaveChanges();
            }
            return RedirectToAction("AdminMemberList", "AdminMemberList");
        }

        public IActionResult Edit(int? id)
        {
            if (HttpContext.Session.Keys.Contains(CDictionary.SK_LOGINED_USE))
            {
                CMemberViewModel memVModel = new CMemberViewModel();
                memVModel.MemberId = _context.Members.FirstOrDefault(c => c.MemberId == id).MemberId;
                memVModel.MemberName = _context.Members.FirstOrDefault(c => c.MemberId == id).MemberName;  //單欄項目顯示!!
                memVModel.Password= _context.Members.FirstOrDefault(c => c.MemberId == id).Password;
                memVModel.Email = _context.Members.FirstOrDefault(c => c.MemberId == id).Email;
                memVModel.IcCardNo = _context.Members.FirstOrDefault(c => c.MemberId == id).IcCardNo;
                memVModel.IdentityId = _context.Members.FirstOrDefault(c => c.MemberId == id).IdentityId;
                memVModel.Address = _context.Members.FirstOrDefault(c => c.MemberId == id).Address;
                memVModel.BirthDay = _context.Members.FirstOrDefault(c => c.MemberId == id).BirthDay;
                memVModel.Phone = _context.Members.FirstOrDefault(c => c.MemberId == id).Phone;
                //============================================ //下拉選單所選項目顯示
                memVModel.Role = _context.Members.FirstOrDefault(c => c.MemberId == id).Role;
                memVModel.GenderId = _context.Members.FirstOrDefault(c => c.MemberId == id).GenderId;
                memVModel.CityId = _context.Members.FirstOrDefault(c => c.MemberId == id).CityId;
                //============================================
                memVModel.roleTypes = _context.RoleTypes.ToList();  //下拉選單顯示
                memVModel.MemGender = _context.Genders.ToList();
                memVModel.MemCity = _context.Cities.ToList();
                return View(memVModel);
            }
            return RedirectToAction("AdminMemberList", "AdminMemberList");
        }
        [HttpPost]
        public IActionResult Edit(CMemberViewModel vm)
        {
            //_context.Members.Add(vm.member);   //這樣寫會新增一筆
            Member mem = _context.Members.FirstOrDefault(c => c.MemberId == vm.MemberId);//這裡要等於vm.MemberId而不是@Html.ActionLink的id
            if (mem != null)
            {
                mem.MemberId = vm.MemberId;
                mem.MemberName = vm.MemberName; 
                mem.Email = vm.Email;
                mem.IdentityId = vm.IdentityId;
                mem.Password = vm.Password;
                mem.BirthDay = vm.BirthDay;
                mem.GenderId = vm.GenderId;
                mem.IcCardNo = vm.IcCardNo;
                mem.Phone = vm.Phone;         
                mem.Role = vm.Role;
                mem.CityId = vm.CityId;
                mem.Address = vm.Address;


                _context.SaveChanges();
            }


            return RedirectToAction("AdminMemberList","AdminMemberList");
        }

        //=================for Ajax API

        //public IActionResult showRolebyAjax(CMemberAdminViewModel AdminVModel)
        //{

        //    Member mb = _context.Members.FirstOrDefault(n => n.Email == AdminVModel.Email);
        //    if (String.IsNullOrEmpty(AdminVModel.Email))
        //    {
        //        AdminVModel.emailState = "請填入信箱";
        //    }
        //    else if (mb != null)
        //    {
        //        AdminVModel.emailState = "帳號已存在";
        //    }
        //    else
        //    {
        //        user.emailState = "帳號可使用";
        //    }

        //    return Content(user.emailState, "text/html", System.Text.Encoding.UTF8);
        //}


    }
}
