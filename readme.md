A simple api for published Umbraco 6+ (and 7) content. Made for Ajax queries.

Using tapasClient.js:

Get and iterate all content

	tapasClient.getDescendantsAndSelf().done(function(children){
		for (var child in children) {
			console.log(children[child].Name + "," + children[child].Url);
		}
	});

	$.ajax({url:"/umbraco/publishedcontent/nodes/getdescendantsandself"}).done(...)

Get and iterate navigation tree (only navigation properties):

    var logChildren = function(children) {
		for (var child in children) {
			console.log(children[child].Name + "," + children[child].NiceUrl);
			logChildren(children[child].Children);
		}
	};
	tapasClient.getNavigationTree().done(logChildren);

	$.ajax({url:"/umbraco/publishedcontent/nodes/getnavigationtree"}).done(...)



###TapasClient has the following functions:
####Returns (with the promise interface) node/s with all properties:
* getNode
* getChildren
* getParent
* getAncestors
* getDescendantsAndSelf

####Returns (with the promise interface) tree with only navigation properties (Id, NiceUrl, Name and Visible):
* getNavigationTree

####Parameters (same for all functions):
* getNode(nodeid:number)
* getNode(path:string)
* getNode() use current path

##Using the http api directly:
Api starts at 

	/umbraco/publishedcontent

All requests must be as GET and as application/json (so you'll need fiddler/curl/restconsole to try it)

###Returns a single node:

	/node/getnode/{id} : gets node by id
	/node/getnode?url=.. : gets node by path

	/node/getparent/{id} : gets parent of 1065
	/node/getparent?url=...

###Returns array of nodes:

	/nodes/getchildren/{id} : gets all child nodes of the node with that id 
	/nodes/getchildren?url=...

	/nodes/getancestors/{id}
	/nodes/getancestors?url=...


###Returns hierarchy of nodes:

	/nodes/getdescendantsorself/{id}
	/nodes/getdescendantsorself?url=...


###Returns navigation tree (only name, url, id & visible) of nodes:

	/nodes/getnavigationtree/{id}
	/nodes/getnavigationtree?url=...


###Node format for single node

	{
		"Id": 1087,
		"Name": "Bar",
		"Url": "/foo/bar/",
		"Visible": true,
		"CreateDate": "2013-09-20T06:27:16",
		"UpdateDate": "2013-09-20T06:35:25",
		"Level": 3,
		"SortOrder": 3,
		"UrlName": "bar",
		"DocumentTypeAlias": "content",
		"WriterId": 0,
		"WriterName": "admin",
		"TemplateId": 1093,
		"Properties": {
			"umbracoNaviHide": "0",
			"contactPerson": "",
			"pageAdministrator": "",
			"linkedNodes": "",
			"bodyText": "<p>yada yada yada</p>",
			"header": "",
			"introduction": ""
		},
		"ParentId": 1086,
		"ChildIds": [1089,1090]
	}

###Format for navigation tree

	{
		"NiceUrl": "/some-root/",
		"Name": "Some Root",
		"Visible": false,
		"Id": 1081,
		"UrlName": "some-root",
		"Children": [{
			"NiceUrl": "/somechild/",
			"Name": "Some child",
			"Visible": true,
			"Id": 1084,
			"UrlName": "somechild",
			"Children": []
		}, {
			"NiceUrl": "/some-other-child/",
			"Name": "Some other child",
			"Visible": true,
			"Id": 1086,
			"UrlName": "some-other-child",
			"Children": [{
				...
			}, {
				...
			}, {
				...
			}]
		}]
	}
