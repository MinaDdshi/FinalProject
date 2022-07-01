﻿using QuestionAnswerBackend.Api.Base;
using QuestionAnswerBackend.Business.Contract;
using QuestionAnswerBackend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAnswerBackend.Api.Controllers;

public class UserController : BaseController<User>
{
	public UserController(IBaseBusiness<User> business) : base(business)
	{
	}
}
