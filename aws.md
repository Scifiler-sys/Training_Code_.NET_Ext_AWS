# AWS EKS (Amazon Web Service Elastic Kubernetes Service)

## IAM User 
IAM user in AWS is a type of user, who is granted certain set of privileges to be able to interact with certain resources. We do it by assigning that user to a user group or assigning policies directly to the user. We shouldn't use root user to interact with EKS resources, so we're going to create an IAM user to manage the EKS cluster.

## VPC - Virtual Private Cloud
This provides a virtual private cloud for us, so we can group resources under one roof and provide control access and security. We need to store all the things we need for our cluster in one VPC

## AWS CLI
AWS cli is a command line interface to interact with aws resources.
[Get it here](https://aws.amazon.com/cli/)

## Steps

1. Log in as a root user and create an IAM user with EKS Full Access policy
    1. Create a new policy that grants full access to EKS resources
    ```json
    {
        "Version": "2012-10-17",
        "Statement": [
            {
                "Effect": "Allow",
                "Action": [
                    "eks:*"
                ],
                "Resource": "*"
            }
        ]
    }
    ```
    2. Create a new user and attach the aforementioned policy to it
        - Check both credential types, programmatic access and password
        - Make sure to save the credential given to you at the end, because you won't be able to access this after you exit this page

2. Create a new VPC stack with the template AWS provides for us, from CloudFormation
    - use this template url: `https://amazon-eks.s3.us-west-2.amazonaws.com/cloudformation/2020-10-29/amazon-eks-vpc-private-subnets.yaml`
    - make sure you give it a relevant name

3. Log out from root user and then log in as the newly created IAM user

4. Navigate to EKS, and then click create new cluster
    1. Create a new IAM role, that will allow the cluster's control panel to be able to interact with other resources in EKS
        - Select AWS Service, and then EKS, and then EKS-Cluster
    2. Once you've created the role, come back to EKS cluster creation panel, and select that role after refreshing the dropdown.
    3. Rest of the options, you should be able to leave at default selections.

5. Once the cluster is up and running, go to cluster, and click configuration and then compute tab

6. Create a new node group
    - This will involve creating another IAM role for nodes to use
        - Trusted Entity Type: AWS Service
        - Use Case: EC2
        - Then attach 3 policies:
            - AmazonEKSWorkerNodePolicy
            - AmazonEC2ContainerRegistryReadOnly
            - AmazonEKS_CNI_Policy
        - [AWS Tutorial](https://docs.aws.amazon.com/eks/latest/userguide/create-node-role.html#create-worker-node-role)
    - Once you create the node group, nodes will be created with EC2 instances

7. Go to your terminal and type `aws configure` to configure your default profile. (go grab that credential csv you downloaded)
    - Enter your access key, secret, default region, and default output format (json)

8. Configure your kubectl to connect to a certain cluster, by using the following command:
    `aws eks update-kubeconfig --name <cluster-name> --region <region-name>`

9. Test the connection to the cluster by running any of the `kubectl get` commands
such as `kubectl get nodes`

10. Now you are connected! Apply your configuration files using `kubectl apply -f <path-to-file>`

11. In order to use ingress, we need to install and configure the ingress controller. It is easy to do by using Helm chart
[Link to Ingress Controller using ngnix](https://artifacthub.io/packages/helm/ingress-nginx/ingress-nginx)

    - *Make sure you have helm installed
    - `helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx`
    - `helm install ingress-nginx ingress-nginx/ingress-nginx`

12. Wait a couple minutes for ingress to configure, but you should be able to do `kubectl get ingress --all-namespaces` and get the external ip/url to get to your ingress controller.