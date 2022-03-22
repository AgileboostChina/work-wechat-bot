using WorkWechatBotTransfer.Helpers;
using Xunit;

namespace WorkWechatBotTransferUnitTest;

public class BuildMessageHelperTest
{
    [Fact]
    public void BuildPushMessageTest()
    {
        var json = @"
    {
    'object_kind':'push',
    'event_name':'push',
    'before':'0f855378f87daf4f5567bba8da4e961ddcb5836d',
    'after':'0f855378f87daf4f5567bba8da4e961ddcb5836d',
    'ref':'refs/heads/master',
    'checkout_sha':'0f855378f87daf4f5567bba8da4e961ddcb5836d',
    'message':null,
    'user_id':11,
    'user_name':'test',
    'user_username':'test',
    'user_email':'',
    'user_avatar':'',
    'project_id':162,
    'project':{
        'id':162,
        'name':'Work Wechat Bot Transfer',
        'description':'',
        'web_url':'',
        'avatar_url':null,
        'git_ssh_url':'',
        'git_http_url':'.git',
        'namespace':'AgileBoost',
        'visibility_level':0,
        'path_with_namespace':'agileboost/work-wechat-bot-transfer',
        'default_branch':'master',
        'ci_config_path':null,
        'homepage':'',
        'url':'',
        'ssh_url':'',
        'http_url':'.git'
    },
    'commits':[
        {
            'id':'0f855378f87daf4f5567bba8da4e961ddcb5836d',
            'message':'Initialized',
            'title':'Initialized',
            'timestamp':'2020-12-18T11:59:46+00:00',
            'url':'/-/commit/0f855378f87daf4f5567bba8da4e961ddcb5836d',
            'author':{
                'name':'GitLab',
                'email':'root@localhost'
            },
            'added':[
                '.gitignore',
                '.gitlab-ci.yml',
                '.gitpod.yml',
                'Program.cs',
                'README.md',
                'dotnetcore.csproj'
            ],
            'modified':[

            ],
            'removed':[

            ]
        }
    ],
    'total_commits_count':1,
    'push_options':{

    },
    'repository':{
        'name':'Work Wechat Bot Transfer',
        'url':'',
        'description':'企业微信机器人消息转发程序',
        'homepage':'',
        'git_http_url':'.git',
        'git_ssh_url':'',
        'visibility_level':0
    }
}".Replace("'","\"");
        
        var message = BuildMessageHelper.BuildMessage(json);
        Assert.NotEmpty(message);
        Assert.Contains("Initialized from", message);
    }
    
    [Fact]
    public void BuildMergeRequestMessageTest()
    {
        var json = @"
    {
    'object_kind':'merge_request',
    'event_type':'merge_request',
    'user':{
        'id':11,
        'name':'test',
        'username':'test',
        'avatar_url':'',
        'email':'test@qq.com'
    },
    'project':{
        'id':162,
        'name':'Work Wechat Bot Transfer',
        'description':'',
        'web_url':'',
        'avatar_url':null,
        'git_ssh_url':'',
        'git_http_url':'.git',
        'namespace':'AgileBoost',
        'visibility_level':0,
        'path_with_namespace':'agileboost/work-wechat-bot-transfer',
        'default_branch':'master',
        'ci_config_path':null,
        'homepage':'',
        'url':'',
        'ssh_url':'',
        'http_url':''
    },
    'object_attributes':{
        'assignee_id':null,
        'author_id':11,
        'created_at':'2022-03-22 02:52:28 UTC',
        'description':'',
        'head_pipeline_id':null,
        'id':211,
        'iid':1,
        'last_edited_at':null,
        'last_edited_by_id':null,
        'merge_commit_sha':null,
        'merge_error':null,
        'merge_params':{
            'force_remove_source_branch':'0'
        },
        'merge_status':'unchecked',
        'merge_user_id':null,
        'merge_when_pipeline_succeeds':false,
        'milestone_id':null,
        'source_branch':'develop',
        'source_project_id':162,
        'state_id':1,
        'target_branch':'master',
        'target_project_id':162,
        'time_estimate':0,
        'title':'测试合并请求',
        'updated_at':'2022-03-22 02:52:28 UTC',
        'updated_by_id':null,
        'url':'',
        'source':{
            'id':162,
            'name':'Work Wechat Bot Transfer',
            'description':'',
            'web_url':'',
            'avatar_url':null,
            'git_ssh_url':'',
            'git_http_url':'',
            'namespace':'AgileBoost',
            'visibility_level':0,
            'path_with_namespace':'agileboost/work-wechat-bot-transfer',
            'default_branch':'master',
            'ci_config_path':null,
            'homepage':'',
            'url':'',
            'ssh_url':'',
            'http_url':''
        },
        'target':{
            'id':162,
            'name':'Work Wechat Bot Transfer',
            'description':'',
            'web_url':'',
            'avatar_url':null,
            'git_ssh_url':'',
            'git_http_url':'',
            'namespace':'AgileBoost',
            'visibility_level':0,
            'path_with_namespace':'agileboost/work-wechat-bot-transfer',
            'default_branch':'master',
            'ci_config_path':null,
            'homepage':'',
            'url':'',
            'ssh_url':'',
            'http_url':''
        },
        'last_commit':{
            'id':'485ec3ee4d21836af0f7be9e5f385da117222654',
            'message':'测试合并请求',
            'title':'测试合并请求',
            'timestamp':'2022-03-22T10:51:52+08:00',
            'url':'',
            'author':{
                'name':'test',
                'email':'test@qq.com'
            }
        },
        'work_in_progress':false,
        'total_time_spent':0,
        'human_total_time_spent':null,
        'human_time_estimate':null,
        'assignee_ids':[

        ],
        'state':'opened',
        'action':'open'
    },
    'labels':[

    ],
    'changes':{
        'author_id':{
            'previous':null,
            'current':11
        },
        'created_at':{
            'previous':null,
            'current':'2022-03-22 02:52:28 UTC'
        },
        'description':{
            'previous':null,
            'current':''
        },
        'id':{
            'previous':null,
            'current':211
        },
        'iid':{
            'previous':null,
            'current':1
        },
        'merge_params':{
            'previous':{

            },
            'current':{
                'force_remove_source_branch':'0'
            }
        },
        'source_branch':{
            'previous':null,
            'current':'develop'
        },
        'source_project_id':{
            'previous':null,
            'current':162
        },
        'target_branch':{
            'previous':null,
            'current':'master'
        },
        'target_project_id':{
            'previous':null,
            'current':162
        },
        'title':{
            'previous':null,
            'current':'测试合并请求'
        },
        'updated_at':{
            'previous':null,
            'current':'2022-03-22 02:52:28 UTC'
        }
    },
    'repository':{
        'name':'Work Wechat Bot Transfer',
        'url':'',
        'description':'',
        'homepage':''
    }
}".Replace("'","\"");
        
        var message = BuildMessageHelper.BuildMessage(json);
        Assert.NotEmpty(message);
        Assert.Contains("测试合并请求", message);
    }
}